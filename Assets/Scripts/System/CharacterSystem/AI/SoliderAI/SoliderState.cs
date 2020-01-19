using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defence
{
    public enum SoliderStateTransition
    {
        NullTransition = 0,
        Idle = 1,
        Chase = 2,
        Attack = 3
    }

    public enum SoliderStateId
    {
        NullId = 0,
        Attack = 1,
        Idle = 2,
        Chase = 3
    }


    //角色状态
    public abstract class SoliderState
    {
        private readonly Dictionary<SoliderStateTransition, SoliderStateId> _map = new Dictionary<SoliderStateTransition, SoliderStateId>();

        public SoliderStateId StateId { get; protected set; }

        public SoliderStateSystem SoliderSystem { get; protected set; }

        protected SoliderState(SoliderStateSystem system, SoliderStateId stateId)
        {
            SoliderSystem = system;
            StateId = stateId;
        }


        public void AddTransition(SoliderStateTransition tran, SoliderStateId stateId)
        {
            if (tran == SoliderStateTransition.NullTransition)
            {
                throw new System.Exception($"不存在的条件{tran}");
            }

            if (stateId == SoliderStateId.NullId)
            {
                throw new System.Exception($"空的ID{stateId}");
            }

            if (_map.ContainsKey(tran))
            {
                throw new System.Exception("已经存在的状态");
            }

            _map.Add(tran, stateId);
        }

        public void DeleteTransition(SoliderStateTransition tran)
        {
            if (tran == SoliderStateTransition.NullTransition)
            {
                throw new System.Exception("空的状态");
            }

            if (_map.ContainsKey(tran))
            {
                _map.Remove(tran);
                return;
            }

            throw new System.Exception("不存在此状态");
        }

        public SoliderStateId GetOutputState(SoliderStateTransition tran)
        {
            if (_map.Count > 0 && _map.ContainsKey(tran))
            {
                return _map[tran];
            }

            return SoliderStateId.NullId;
        }

        public virtual void DoBeforeEntering()
        {
        }

        public virtual void DoBeforeLeaving()
        {
        }

        public abstract void Reason();

        public abstract void Atc();
    }

    //状态管理
    public class SoliderStateSystem
    {
        private readonly List<SoliderState> _states = new List<SoliderState>();

        public SoliderState CurrentState { get; private set; }

        public void AddState(params SoliderState[] states)
        {
            foreach (var s in states)
            {
                AddState(s);
            }
        }

        public void AddState(SoliderState state)
        {
            if (state == null)
            {
                throw new System.Exception("空的状态");
            }

            if (_states.Count == 0)
            {
                CurrentState = state;
                _states.Add(state);
                return;
            }

            foreach (var s in _states)
            {
                if (s.StateId == state.StateId)
                {
                    throw new System.Exception("已经存在的状态");
                }
            }

            _states.Add(state);
        }

        public void DeleteState(SoliderState state)
        {
            if (state == null)
            {
                throw new System.Exception("空的状态");
            }

            foreach (var s in _states)
            {
                if (s.StateId == state.StateId)
                {
                    _states.Remove(state);
                    return;
                }
            }

            throw new System.Exception("不存在的状态");
        }

        public void PerformTransition(SoliderStateTransition tran)
        {
            SoliderStateId tempStateId = CurrentState.GetOutputState(tran);

            if (tempStateId == SoliderStateId.NullId)
            {
                throw new System.Exception("不存在的状态");
            }

            foreach (var s in _states)
            {
                if (s.StateId != tempStateId) continue;
                CurrentState.DoBeforeLeaving();
                CurrentState = s;
                CurrentState.DoBeforeEntering();
                return;
            }

            throw new System.Exception("无法转换到此状态状态");
        }
    }
}
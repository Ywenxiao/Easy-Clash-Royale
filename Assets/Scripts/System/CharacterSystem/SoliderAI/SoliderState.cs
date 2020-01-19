using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBase
{
    public enum SoliderTransition
    {
        NullTransition = 0,
        Idle = 1,
        Chase = 2,
        Attack = 3
    }

    public enum SoliderId
    {
        NullId = 0,
        Attack = 1,
        Idle = 2,
        Chase = 3
    }

    public abstract class SoliderState 
    {
        private readonly Dictionary<SoliderTransition, SoliderId> _map = new Dictionary<SoliderTransition, SoliderId>();

        public SoliderId Id { get; protected set; }

        public SoliderStateSystem SoliderSystem { get; protected set; }

        protected SoliderState(SoliderStateSystem system, SoliderId id)
        {
            SoliderSystem = system;
            Id = id;
        }


        public void AddTransition(SoliderTransition tran, SoliderId id)
        {
            if (tran == SoliderTransition.NullTransition)
            {
                throw new System.Exception($"不存在的条件{tran}");
            }

            if (id == SoliderId.NullId)
            {
                throw new System.Exception($"空的ID{id}");
            }

            if (_map.ContainsKey(tran))
            {
                throw new System.Exception("已经存在的状态");
            }

            _map.Add(tran, id);
        }

        public void DeleteTransition(SoliderTransition tran)
        {
            if (tran == SoliderTransition.NullTransition)
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

        public SoliderId GetOutputState(SoliderTransition tran)
        {
            if (_map.Count > 0 && _map.ContainsKey(tran))
            {
                return _map[tran];
            }

            return SoliderId.NullId;
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
                if (s.Id == state.Id)
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
                if (s.Id == state.Id)
                {
                    _states.Remove(state);
                    return;
                }
            }

            throw new System.Exception("不存在的状态");
        }

        public void PerformTransition(SoliderTransition tran)
        {
            SoliderId tempId = CurrentState.GetOutputState(tran);

            if (tempId == SoliderId.NullId)
            {
                throw new System.Exception("不存在的状态");
            }

            foreach (var s in _states)
            {
                if (s.Id != tempId) continue;
                CurrentState.DoBeforeLeaving();
                CurrentState = s;
                CurrentState.DoBeforeEntering();
                return;
            }
            throw new System.Exception("无法转换到此状态状态");
        }

    }
}
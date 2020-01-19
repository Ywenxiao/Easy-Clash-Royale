using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defence
{
    public enum EnemyTransition
    {
        NullTransition,
        Chase,
        Attack
    }

    public enum EnemyId
    {
        NullId,
        Chase,
        Attack,
    }

    public abstract class EnemyState
    {
        private readonly Dictionary<EnemyTransition, EnemyId> _map = new Dictionary<EnemyTransition, EnemyId>();

        public EnemyId StateId { get; protected set; }

        public EnemyStateSystem SoliderSystem { get; protected set; }

        protected EnemyState(EnemyStateSystem system, EnemyId stateId)
        {
            SoliderSystem = system;
            StateId = stateId;
        }


        public void AddTransition(EnemyTransition tran, EnemyId stateId)
        {
            if (tran == EnemyTransition.NullTransition)
            {
                throw new System.Exception($"不存在的条件{tran}");
            }

            if (stateId == EnemyId.NullId)
            {
                throw new System.Exception($"空的ID{stateId}");
            }

            if (_map.ContainsKey(tran))
            {
                throw new System.Exception("已经存在的状态");
            }

            _map.Add(tran, stateId);
        }

        public void DeleteTransition(EnemyTransition tran)
        {
            if (tran == EnemyTransition.NullTransition)
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

        public EnemyId GetOutputState(EnemyTransition tran)
        {
            if (_map.Count > 0 && _map.ContainsKey(tran))
            {
                return _map[tran];
            }

            return EnemyId.NullId;
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


    public class EnemyStateSystem
    {
        private readonly List<EnemyState> _states = new List<EnemyState>();

        public EnemyState CurrentState { get; private set; }

        public void AddState(params EnemyState[] states)
        {
            foreach (var s in states)
            {
                AddState(s);
            }
        }

        public void AddState(EnemyState state)
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

        public void DeleteState(EnemyState state)
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

        public void PerformTransition(EnemyTransition tran)
        {
            EnemyId tempStateId = CurrentState.GetOutputState(tran);

            if (tempStateId == EnemyId.NullId)
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
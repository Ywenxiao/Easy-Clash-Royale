using System;
using System.Collections.Generic;
using UnityEngine;

namespace FsmStateFsm
{
    /// <summary>
    /// 状态ID
    /// </summary>
    public enum StateId
    {
        NullStateId = 0,
        State01,
        State02,
        State03,
        State04
    }

    /// <summary>
    /// 状态转换条件
    /// </summary>
    public enum Transition
    {
        NullTransition = 0,
        Transition01,
        Transition02,
        Transition03,
        Transition04
    }


    public abstract class FsmState
    {
        public StateId Id { get; }

        protected readonly Dictionary<Transition, StateId> map = new Dictionary<Transition, StateId>();

        protected FsmSystem system;

        protected FsmState(FsmSystem system, StateId trans)
        {
            this.system = system;
            Id = trans;
        }

        /// <summary>
        /// 添加状态转换
        /// </summary>
        public void AddTransition(Transition transition, StateId stateId)
        {
            if (transition == Transition.NullTransition)
            {
                throw new Exception("Null transition");
            }

            if (stateId == StateId.NullStateId)
            {
                throw new Exception("Null EnemyId");
            }

            if (map.ContainsKey(transition))
            {
                throw new Exception("已经存在的状态");
            }

            map.Add(transition, stateId);
        }

        /// <summary>
        /// 删除状态
        /// </summary>
        public void DeleteTransition(Transition transition)
        {
            if (transition == Transition.NullTransition)
            {
                throw new Exception("Null Transition");
            }

            if (map.ContainsKey(transition))
            {
                map.Remove(transition);
                return;
            }

            throw new Exception("不存在的状态");
        }

        /// <summary>
        /// 获取transition条件下的状态  
        /// </summary>
        /// <returns></returns>
        public StateId GetOutputState(Transition transition)
        {
            if (map.ContainsKey(transition))
            {
                return map[transition];
            }

            return StateId.NullStateId;
        }

        /// <summary>
        /// 当进入状态的时候调用
        /// </summary>
        public virtual void DoBeforeEntering()
        {
        }

        /// <summary>
        /// 当离开状态的时候调用
        /// </summary>
        public virtual void DoBeforeLeaving()
        {
        }

        /// <summary>
        /// 何时切换到其它状态状态
        /// </summary>
        public abstract void Reason();

        /// <summary>
        /// 当前状态需要的操作
        /// </summary>
        public abstract void Act();
    }

    //状态管理
    public class FsmSystem
    {
        private readonly List<FsmState> _states;

        public StateId CurrentId => CurrentState.Id;

        public FsmState CurrentState { get; private set; }

        public FsmSystem()
        {
            _states = new List<FsmState>();
        }

        /// <summary>
        /// 添加状态
        /// </summary>
        public void AddState(FsmState state)
        {
            if (state == null)
            {
                throw new Exception("Null Refence to FsmStateTest");
            }

            if (_states.Count == 0)
            {
                _states.Add(state);
                CurrentState = state;

                return;
            }


            foreach (var stateSign in _states)
            {
                if (stateSign.Id == state.Id)
                {
                    throw new Exception("已经存在的状态");
                }
            }

            _states.Add(state);
        }

        /// <summary>
        /// 删除状态
        /// </summary>
        public void DeleteState(StateId id)
        {
            if (id == StateId.NullStateId)
            {
                throw new Exception("移除空状态的状态");
            }

            foreach (var s in _states)
            {
                if (id == s.Id)
                {
                    _states.Remove(s);
                    return;
                }
            }

            throw new Exception("不存在的状态");
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="transition"></param>
        public void PerformTransition(Transition transition)
        {
          
            if (transition == Transition.NullTransition)
            {
                throw new Exception("不存在的转换条件");
            }

            StateId id = CurrentState.GetOutputState(transition);

            foreach (var s in _states)
            {
                if (s.Id != id) continue;

                //上个状态结束需要的操作
                CurrentState.DoBeforeLeaving();

                CurrentState = s;

                //下个状态开始需要的操作
                CurrentState.DoBeforeEntering();
                return;
            }

            throw new Exception("无法转换此状态");
        }
    }
}
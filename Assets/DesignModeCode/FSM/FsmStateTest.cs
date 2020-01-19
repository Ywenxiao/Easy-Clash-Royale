using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Transition
{
    NullTransition = 0,
}

public enum StateId
{
    NullStateId = 0,
}


public abstract class FsmStateTest
{
    protected readonly Dictionary<Transition, StateId> map = new Dictionary<Transition, StateId>();

    public StateId Id { get; }

    protected FsmSystem System { get; }

    protected FsmStateTest( FsmSystem system, StateId id)
    {
        Id = id;
        System = system;
    }

    public void AddTransition(Transition tran, StateId id)
    {
        if (tran == Transition.NullTransition)
        {
            throw new Exception("空的转换条件");
        }

        if (id == StateId.NullStateId)
        {
            throw new Exception("空的状态");
        }

        if (map.ContainsKey(tran))
        {
            throw new Exception("已经存在的状态");
        }

        map.Add(tran, id);
    }

    public void DeleteTransition(Transition tran)
    {
        if (tran == Transition.NullTransition)
        {
            throw new Exception("空的转换条件");
        }

        if (map.ContainsKey(tran))
        {
            map.Remove(tran);
            return;
        }

        throw new Exception("不存在的状态");
    }

    public StateId GetStateId(Transition tran)
    {
        if (tran == Transition.NullTransition)
        {
            throw new Exception("空的状态");
        }

        if (map.ContainsKey(tran))
        {
            return map[tran];
        }

        throw new Exception("不存在的状态");
    }

    public virtual void DoBeforeEntering()
    {
    }

    public virtual void DoBeforeLeaving()
    {
    }

    public abstract void Reason();

    public abstract void Act();
}


public class FsmSystem
{
    private readonly List<FsmStateTest> _states;

    public StateId CurrentId => CurrentState.Id;

    public FsmStateTest CurrentState { get; private set; }

    public FsmSystem()
    {
        _states = new List<FsmStateTest>();
    }

    public void AddState(FsmStateTest state)
    {
        if (state == null)
        {
            throw new Exception("空的状态");
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
                throw new Exception("已经存在的状态");
            }
        }

        _states.Add(state);
    }

    public void DeleteState(StateId id)
    {
        if (id == StateId.NullStateId)
        {
            throw new Exception("空的状态");
        }

        foreach (var s in _states)
        {
            if (s.Id == id)
            {
                _states.Remove(s);
                return;
            }
        }

        throw new Exception("不存在的状态");
    }

    public void PerformTransition(Transition tran)
    {
        if (tran == Transition.NullTransition)
        {
            throw new Exception("不存在的状态");
        }

        StateId id = CurrentState.GetStateId(tran);

        foreach (var s in _states)
        {
            if (s.Id != id) continue;

            CurrentState.DoBeforeLeaving();

            CurrentState = s;

            CurrentState.DoBeforeEntering();
            return;
        }

        throw new Exception("无法转换此状态");
    }
}
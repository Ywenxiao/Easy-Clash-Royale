using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.DesignModeCode.StateMode
{
    public class Context
    {
        private  IState _state;

        public void SetState(IState state)
        {
            _state = state;
        }

        public void Handle(int arg)
        {
            _state.Handle(arg);
        }
    }

    public interface IState
    {
        void Handle(int arg);
    }

    public class ConcreteA : IState
    {
        private readonly Context _context;

        public ConcreteA(Context context)
        {
            _context = context;
        }
        public void Handle(int arg)
        {
            Debug.Log("执行状态A");
            if (arg > 10)
            {
                //TODO
                _context.SetState(new ConcreteB(_context));
            }
        }
    }

    public class ConcreteB : IState
    {
        private readonly Context _context;

        public ConcreteB(Context context )
        {
            _context = context;
        }
        public void Handle(int arg)
        {
            Debug.Log("执行状态B");
            if (arg <= 10)
            {
                //TODO
                _context.SetState(new ConcreteA(_context));
            }
        }
    }
}
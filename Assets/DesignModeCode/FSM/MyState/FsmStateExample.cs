using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FsmStateFsm
{
    public class FsmStateExample : MonoBehaviour
    {
        private FsmSystem _manage;
       
        void Start()
        {
            MakeState();
        }
       

        private void FixedUpdate()
        {
            _manage.CurrentState.Reason();
            _manage.CurrentState.Act();
        }

        /// <summary>
        /// 构造有限状态机
        /// </summary>
        private void MakeState()
        {
            _manage = new FsmSystem();//状态管理

            FsmState state01 = new State01(_manage, StateId.State01);
            FsmState state02 = new State02(_manage, StateId.State02);
            FsmState state03 = new State03(_manage, StateId.State03);
            FsmState state04 = new State04(_manage, StateId.State04);

            state01.AddTransition(Transition.Transition02, StateId.State02);
            state01.AddTransition(Transition.Transition03, StateId.State03);
            state01.AddTransition(Transition.Transition04, StateId.State04);

            state02.AddTransition(Transition.Transition01, StateId.State01);

            state03.AddTransition(Transition.Transition02, StateId.State02);
            state04.AddTransition(Transition.Transition02, StateId.State02);

            _manage.AddState(state01);
            _manage.AddState(state02);
            _manage.AddState(state03);
            _manage.AddState(state04);
        }
    }

    //状态1
    class State01 : FsmState
    {
        public override void Act()
        {
            Debug.Log("正在执行状态01");
        }

        public override void Reason()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                system.PerformTransition(Transition.Transition02);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                system.PerformTransition(Transition.Transition03);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                system.PerformTransition(Transition.Transition04);
            }
        }

        public override void DoBeforeEntering()
        {
            Debug.Log("进入状态01");
        }

        public override void DoBeforeLeaving()
        {
            Debug.Log("离开状态01");
        }


        public State01(FsmSystem system, StateId id) : base(system, id)
        {
        }
    }

    //状态2
    class State02 : FsmState
    {
        public override void Act()
        {
            Debug.Log("正在执行状态02");
        }

        public override void Reason()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                system.PerformTransition(Transition.Transition01);
            }
        }

        public override void DoBeforeEntering()
        {
            Debug.Log("进入状态02");
        }

        public override void DoBeforeLeaving()
        {
            Debug.Log("离开状态02");
        }

        public State02(FsmSystem system, StateId id) : base(system, id)
        {
        }
    }

    //状态3
    class State03 : FsmState
    {
        public override void Act()
        {
            Debug.Log("正在执行状态03");
        }

        public override void Reason()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                system.PerformTransition(Transition.Transition02);
            }
        }

        public override void DoBeforeEntering()
        {
            Debug.Log("进入状态03");
        }

        public override void DoBeforeLeaving()
        {
            Debug.Log("离开状态03");
        }

        public State03(FsmSystem system, StateId id) : base(system, id)
        {
        }
    }

    //状态4
    class State04 : FsmState
    {
        public override void Act()
        {
            Debug.Log("正在执行状态04");
        }

        public override void Reason()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                system.PerformTransition(Transition.Transition02);
            }
        }

        public override void DoBeforeEntering()
        {
            Debug.Log("进入状态04");
        }

        public override void DoBeforeLeaving()
        {
            Debug.Log("离开状态04");
        }

        public State04(FsmSystem system, StateId id) : base(system, id)
        {
        }
    }
}
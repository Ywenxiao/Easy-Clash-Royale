using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBase
{
    public class Solider : Character
    {
        public SoliderStateSystem system;

        protected override void Start()
        {
            base.Start();
            MakeState();
        }
        protected override void FixedUpdate()
        {
            system.CurrentState.Reason();
            system.CurrentState.Atc();
        }

        /// <summary>
        /// 构造状态机
        /// </summary>
        private void MakeState()
        {
            system = new SoliderStateSystem();
            SoliderState idleState = new IdleState(system, SoliderId.Idle);
            SoliderState chaseState = new ChaseState(system, SoliderId.Chase);
            SoliderState attackState = new AttackState(system, SoliderId.Attack);

            // idleState.AddTransition(SoliderTransition.Idle, SoliderId.Idle);
            idleState.AddTransition(SoliderTransition.Chase, SoliderId.Chase);
            
            chaseState.AddTransition(SoliderTransition.Attack, SoliderId.Attack);
            chaseState.AddTransition(SoliderTransition.Idle, SoliderId.Idle);
            chaseState.AddTransition(SoliderTransition.Attack, SoliderId.Attack);

            attackState.AddTransition(SoliderTransition.Idle, SoliderId.Idle);
            attackState.AddTransition(SoliderTransition.Chase, SoliderId.Chase);

            system.AddState(idleState, chaseState, attackState);
        }
    }
}
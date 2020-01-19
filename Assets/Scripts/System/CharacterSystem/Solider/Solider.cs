using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defence
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
            SoliderState idleState = new SoliderIdleState(system, SoliderStateId.Idle);
            SoliderState chaseState = new SoliderChaseState(system, SoliderStateId.Chase);
            SoliderState attackState = new SoliderAttackState(system, SoliderStateId.Attack);

            // idleState.AddTransition(SoliderStateTransition.Idle, SoliderStateId.Idle);
            idleState.AddTransition(SoliderStateTransition.Chase, SoliderStateId.Chase);
            
            chaseState.AddTransition(SoliderStateTransition.Attack, SoliderStateId.Attack);
            chaseState.AddTransition(SoliderStateTransition.Idle, SoliderStateId.Idle);
            chaseState.AddTransition(SoliderStateTransition.Attack, SoliderStateId.Attack);

            attackState.AddTransition(SoliderStateTransition.Idle, SoliderStateId.Idle);
            attackState.AddTransition(SoliderStateTransition.Chase, SoliderStateId.Chase);

            system.AddState(idleState, chaseState, attackState);
        }
    }
}
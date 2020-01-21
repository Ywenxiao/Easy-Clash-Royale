using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defence
{
    public class Enemy : Character
    {
        private EnemyStateSystem _enemyState;
        protected override void Start()
        {
            base.Start();
            Mask();
        }
        protected override void FixedUpdate()
        {
            _enemyState.CurrentState.Reason();
            _enemyState.CurrentState.Atc();
        }

        /// <summary>
        /// 构造敌人状态机
        /// </summary>
        private void Mask()
        {
            _enemyState = new EnemyStateSystem();

            EnemyState chase = new EnemyChaseState(_enemyState, EnemyId.Chase);
            EnemyState attack = new EnemyAttackState(_enemyState,EnemyId.Attack);

            chase.AddTransition(EnemyTransition.Chase, EnemyId.Chase);
            attack.AddTransition(EnemyTransition.Attack, EnemyId.Attack);

            _enemyState.AddState(chase,attack);
        }
    }
}

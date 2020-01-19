using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.AI;
using UnityEngine;

namespace Defence
{
    public abstract class Character : MonoBehaviour
    {
        /// <summary>
        /// 角色名字    
        /// </summary>
        protected string characterName;

        /// <summary>
        /// 角色最大血量
        /// </summary>
        protected int maxHp;

        /// <summary>
        /// 角色当前血量
        /// </summary>
        protected int currentHp;

        /// <summary>
        /// 角色移动速度
        /// </summary>
        protected float moveSpeed;

        /// <summary>
        /// 角色等级
        /// </summary>
        protected int lv;

        /// <summary>
        /// 角色暴击率
        /// </summary>
        protected float criticalRate;

        #region 角色所需组件

        protected AudioSource audioClip;
        protected NavMeshAgent navMeshAgent;

        #endregion

        protected virtual void Start()
        {
            audioClip = GetComponent<AudioSource>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        

        protected virtual void FixedUpdate() { }
        /// <summary>
        /// 角色攻击方法
        /// </summary>
        public virtual void Attack(Vector3 point)
        {
            Debug.Log("攻击");
        }
    }
}
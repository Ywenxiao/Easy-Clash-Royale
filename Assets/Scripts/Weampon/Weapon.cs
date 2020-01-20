using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defence
{
    public enum WeaponType
    {
        Gun,
        Rifle,
        Rocket
    }

    public abstract class Weapon : MonoBehaviour
    {
        public int atk;            //攻击力
        public float atkRange;     //攻击范围
        public float atkPlusValue; //攻击加成

        protected Character character; //持武器的角色

        #region 武器特效组件

        [HideInInspector] public ParticleSystem effectsGun;
        [HideInInspector] public AudioSource audioSource;
        [HideInInspector] public LineRenderer lineRenderer;
        [HideInInspector] public Light effectLight;

        #endregion

        protected virtual void Start()
        {
            // Init();//TODO 武器组件初始化
        }

        private void Init()
        {
            effectsGun = GetComponent<ParticleSystem>();
            audioSource = GetComponent<AudioSource>();
            lineRenderer = GetComponent<LineRenderer>();
            effectLight = GetComponent<Light>();
        }

        /// <summary>
        /// 开枪
        /// </summary>
        public virtual void Fire(Vector3 targetPosition)
        {
            Debug.Log("播放声音");
            Debug.Log("播放特效");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defence
{
    public class BattleScene : State
    {
        public override void OnStart()
        {
            Debug.Log("进入游戏场景");
            GameFacade.Instance.Init();
        }

        public override void OnUpdate()
        {
            GameFacade.Instance.Update();
        }

        public override void OnExit()
        {
            GameFacade.Instance.Release();
        }

        public BattleScene( StateControl control) : base("BattleScene", control)
        {
        }
    }
}

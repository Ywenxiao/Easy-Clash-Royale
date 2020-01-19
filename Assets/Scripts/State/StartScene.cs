using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;

namespace MyBase
{
    public class StartScene : State
    {
        private Image _backdrop;

        public float interimTime = 1.5f;

        public override void OnStart()
        {
            _backdrop = GameObject.Find("Canvas/Break").GetComponent<Image>();
            _backdrop.color = Color.black;
        }

        public override void OnUpdate()
        {
            _backdrop.color = Color.Lerp(_backdrop.color, Color.white,  0.1f);
            interimTime -= Time.deltaTime;

            if (interimTime <= 0)
            {
                control.SetScene(new MainMenuScene(control));
            }
        }
       

        public StartScene( StateControl control) : base("StartScene", control)
        {
        }
    }
}

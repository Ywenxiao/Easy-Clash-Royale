using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Defence
{
    public class MainMenuScene : State
    {

        private Button _startGame;

        public override void OnStart()
        {
            _startGame = GameObject.Find("Canvas/UI/StartGame").GetComponent<Button>();
            _startGame.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            control.SetScene(new BattleScene(control));
        }

        public MainMenuScene( StateControl control) : base("MainMenuScene", control)
        {
        }
    }
}

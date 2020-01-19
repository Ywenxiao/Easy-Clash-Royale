using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Defence
{
    public class GameLoop : MonoBehaviour
    {
        private StateControl _gameControl;
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        void Start()
        {
            _gameControl = new StateControl();
            _gameControl.SetScene(new StartScene(_gameControl),false);
        }
        private void Update()
        {
            _gameControl?.StateUpdate();
        }

    }
}
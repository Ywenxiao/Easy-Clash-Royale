using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Defence
{
    public class StateControl
    {
        //当前状态
        private State _currentState = null;

        private AsyncOperation _currentLoadScene;

        //异步加载完成之后调用 OnStart 方法
        private bool _onlyRunStart;

        /// <summary>
        /// 切换场景(状态)
        /// </summary>
        public void SetScene(State state, bool isLoadScene = true)
        {
            _currentState?.OnExit();

            _currentState = state;

            if (isLoadScene)
            {
                _currentLoadScene = SceneManager.LoadSceneAsync(_currentState.SceneName);
                _onlyRunStart = true;
            }
            else
            {
                _currentState?.OnStart();
                _onlyRunStart = false;
            }
        }

        public void StateUpdate()
        {
            if (_currentLoadScene != null && !_currentLoadScene.isDone) return;

            if (_onlyRunStart)
            {
                _onlyRunStart = false;
                _currentState?.OnStart();
            }

            _currentState?.OnUpdate();
        }
    }
}
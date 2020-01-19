using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBase
{
    public class GameFacade
    {
        private static GameFacade _instance;

        private AchievementSystem _achievementSystem; //成就系统
        private CampSystem _campSystem;               //兵营系统
        private CharacterSystem _characterSystem;     //角色系统
        private EnergySystem _energySystem;           //
        private GameEventSystem _gameEventSystem;     //事件系统
        private StageSystem _stageSystem;             //关卡系统

        private CampInfoUI _campInfoUI;           //兵营界面
        private GamePauseUI _gamePauseUI;         //游戏暂停界面
        private GameStateInfoUI _gameStateInfoUI; //游戏状态信息界面
        private SoliderInfoUI _soliderInfoUI;     //战士信息界面


        public static GameFacade Instance => _instance ?? (_instance = new GameFacade());

        public bool OverGame { get; private set; } = false;

        public void Init()
        {
            _achievementSystem = new AchievementSystem();
            _campSystem = new CampSystem();
            _characterSystem = new CharacterSystem();
            _energySystem = new EnergySystem();
            _gameEventSystem = new GameEventSystem();
            _stageSystem = new StageSystem();

            _campInfoUI = new CampInfoUI();
            _gamePauseUI = new GamePauseUI();
            _gameStateInfoUI = new GameStateInfoUI();
            _soliderInfoUI = new SoliderInfoUI();

            _achievementSystem.Init();
            _campSystem.Init();
            _characterSystem.Init();
            _energySystem.Init();
            _gameEventSystem.Init();
            _stageSystem.Init();

            _campInfoUI.Init();
            _gamePauseUI.Init();
            _gameStateInfoUI.Init();
            _soliderInfoUI.Init();
        }

        public void Update()
        {
            _achievementSystem.Update();
            _campSystem.Update();
            _characterSystem.Update();
            _energySystem.Update();
            _gameEventSystem.Update();
            _stageSystem.Update();

            _campInfoUI.Update();
            _gamePauseUI.Update();
            _gameStateInfoUI.Update();
            _soliderInfoUI.Update();
        }

        public void Release()
        {
            _achievementSystem.Release();
            _campSystem.Release();
            _characterSystem.Release();
            _energySystem.Release();
            _gameEventSystem.Release();
            _stageSystem.Release();

            _campInfoUI.Release();
            _gamePauseUI.Release();
            _gameStateInfoUI.Release();
            _soliderInfoUI.Release();
        }
    }
}
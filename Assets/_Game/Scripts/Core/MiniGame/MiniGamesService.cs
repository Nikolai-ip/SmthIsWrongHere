using System;
using System.Collections.Generic;
using _Game.Scripts.Common.Utilities;
using _Game.Scripts.Features.MiniGames;
using UnityEngine;

namespace _Game.Scripts.Core.MiniGame
{
    public class MiniGamesService: IDisposable
    {
        private readonly Dictionary<MiniGameType, MiniGameContext> _miniGames;
        private readonly Camera _mainCamera;
        private MiniGameContext _currentMiniGame;
        public event Action<MiniGameType> OnMiniGameFinished;

        public MiniGamesService(Dictionary<MiniGameType, MiniGameContext> miniGames, Camera mainCamera)
        {
            _mainCamera = mainCamera;
            _miniGames = miniGames;
        }

        public void StartMiniGame(MiniGameType miniGameType)
        {
            if (_currentMiniGame != null) return;
            if (_miniGames.TryGetValue(miniGameType, out var miniGame))
            {
                _currentMiniGame = miniGame;
                SwitchMiniGameCamera(miniGameIsActive: true);
                _currentMiniGame.OnMiniGameExitResult += OnMiniGameResultHandle;
                _currentMiniGame.StartGame();
            }   
            else 
                Debug.LogError($"There is no miniGame object with miniGame key type {miniGameType}");
        }

        private void SwitchMiniGameCamera(bool miniGameIsActive)
        {
            _mainCamera.enabled = !miniGameIsActive;
            _currentMiniGame.Camera.enabled = miniGameIsActive;
        }
        private void OnMiniGameResultHandle(MiniGameResultType resultCallback)
        {
            Debug.Log($"MiniGame {_currentMiniGame.Type} finished with result: {resultCallback}");
            SwitchMiniGameCamera(miniGameIsActive: false);
            DisposeCurrentMiniGame();
            if (resultCallback == MiniGameResultType.Success)
                OnMiniGameFinished?.Invoke(_currentMiniGame.Type);
        }

        private void DisposeCurrentMiniGame()
        {
            _currentMiniGame.OnMiniGameExitResult -= OnMiniGameResultHandle;
            _currentMiniGame = null;
        }

        public void Dispose()
        {
            if (_currentMiniGame != null)
                DisposeCurrentMiniGame();
        }
    }
}
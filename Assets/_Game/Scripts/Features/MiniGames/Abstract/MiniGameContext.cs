using System;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames
{
    public abstract class MiniGameContext:MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private InputListener _inputListener;
        public event Action<MiniGameResultType> OnMiniGameExitResult;
        public event Action OnReset;
        public abstract MiniGameType Type { get; }
        public Camera Camera => _camera;
        public InputListener InputListener => _inputListener;
        protected virtual void OnEnable() => _inputListener.OnGameCloseButton += OnMiniGameClosed;
        protected virtual void OnDisable() => _inputListener.OnGameCloseButton -= OnMiniGameClosed;
        public virtual void OnFailed()
        {
            ResetGame();
        }
        public void OnMiniGameClosed()
        {
            OnMiniGameExitResult?.Invoke(MiniGameResultType.Closed);
            Disable();
        }
        public virtual void OnSuccess()
        {
            OnMiniGameExitResult?.Invoke(MiniGameResultType.Success);
            Disable();
        }

        public virtual void StartGame()
        {
            Debug.Log("Starting game");
            gameObject.SetActive(true);
            InputListener.Enable();
            ResetGame();
        }

        public virtual void ResetGame()
        {
            Debug.Log("Resetting game");
            OnReset?.Invoke();
        }

        public void Disable()
        {
            gameObject.SetActive(false);
            InputListener.Disable();
        }
    }

    public enum MiniGameResultType
    {
        Closed,
        Success
    }
}
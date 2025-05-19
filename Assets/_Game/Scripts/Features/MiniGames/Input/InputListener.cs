using System;
using UnityEngine;

public class InputListener: MonoBehaviour
{
    public event Action OnGameCloseButton;
    public Vector2 MousePos=> _camera.ScreenToWorldPoint(Input.mousePosition);
    public event Action<KeyCode> OnKeyPress;
    private bool _isActive;
    [SerializeField] private Camera _camera;
    
    protected virtual void Update()
    {
        if (!_isActive) return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnGameCloseButton?.Invoke();
        }
    }

    public void Enable() => _isActive = true;
    public void Disable() => _isActive = false;
}
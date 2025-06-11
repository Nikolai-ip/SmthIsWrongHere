using System;
using Tools.DevTools;
using UnityEngine;

public class InputListener: MonoBehaviour
{
    public event Action OnGameCloseButton;
    public Vector2 MousePos=> _camera.ScreenToWorldPoint(Input.mousePosition);
    public event Action<KeyCode> OnKeyPress;
    private bool _isActive;
    [SerializeField] private Camera _camera;
    private float _mouseWheel;
    public event Action<float> OnMouseScroll;
    public float MouseWheel
    {
        get => _mouseWheel;
        private set
        {
            if (!Mathf.Approximately(_mouseWheel, value))
            {
                _mouseWheel = value;
                OnMouseScroll?.Invoke(_mouseWheel);
            }
        }
    }

    protected virtual void Update()
    {
        if (!_isActive) return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnGameCloseButton?.Invoke();
        }

        MouseWheel = Input.GetAxis("Mouse ScrollWheel");
    }

    public void Enable() => _isActive = true;
    public void Disable() => _isActive = false;
}
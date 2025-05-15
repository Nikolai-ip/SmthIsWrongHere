using UnityEngine;

namespace _Game.Scripts.Common.Utilities
{
    public class FPSDisplay: MonoBehaviour
    {
        private float _deltaTime;
        private float _timeElapsed;
        private int _frameCount;
        private float _averageFPS;
        [SerializeField] private int _fontSize;
        [Header("AverageFPSLabel")]
        [SerializeField] private float _averageCalculationInterval;
        [SerializeField] private AnchorRelative _averageFPSanchor;
        [SerializeField] private Vector2 _averageFPSOffset;
        [SerializeField] private Vector2 _averageFPSSize;
        [Header("FPSLabel")]
        [SerializeField] private AnchorRelative _FPSanchor;
        [SerializeField] private Vector2 _FPSOffset;
        [SerializeField] private Vector2 _FPSSize;
        enum AnchorRelative
        {
            UpperLeft,
            UpperRight,
            LowerLeft,
            LowerRight,
            Left,
            Right,
            Center,
            Up,
            Down,
        }
        void Update()
        {
            _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
            _timeElapsed += Time.unscaledDeltaTime;
            _frameCount++;
            if (_timeElapsed >= _averageCalculationInterval)
            {
                _averageFPS = _frameCount / _timeElapsed;
                _timeElapsed = 0.0f;
                _frameCount = 0;
            }
        }

        void OnGUI()
        {
            float fps = 1.0f / _deltaTime;
            string fpsText = string.Format("{0:0.} FPS", fps);
            string averageText = string.Format("Avg: {0:0.} FPS", _averageFPS);
            
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = _fontSize;
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = Color.white;
            
            Rect rectFPS = GetAnchoredRect(_FPSanchor, _FPSOffset, _FPSSize);
            Rect rectAvg = GetAnchoredRect(_averageFPSanchor, _averageFPSOffset, _averageFPSSize);
            
            GUI.Label(rectFPS, fpsText, style);
            GUI.Label(rectAvg, averageText, style);
        }
        
        private Rect GetAnchoredRect(AnchorRelative anchor, Vector2 offset, Vector2 size)
        {
            float x = 0, y = 0;

            switch (anchor)
            {
                case AnchorRelative.UpperLeft:
                    x = offset.x;
                    y = offset.y;
                    break;
                case AnchorRelative.UpperRight:
                    x = Screen.width - size.x - offset.x;
                    y = offset.y;
                    break;
                case AnchorRelative.LowerLeft:
                    x = offset.x;
                    y = Screen.height - size.y - offset.y;
                    break;
                case AnchorRelative.LowerRight:
                    x = Screen.width - size.x - offset.x;
                    y = Screen.height - size.y - offset.y;
                    break;
                case AnchorRelative.Left:
                    x = offset.x;
                    y = (Screen.height - size.y) / 2 + offset.y;
                    break;
                case AnchorRelative.Right:
                    x = Screen.width - size.x - offset.x;
                    y = (Screen.height - size.y) / 2 + offset.y;
                    break;
                case AnchorRelative.Center:
                    x = (Screen.width - size.x) / 2 + offset.x;
                    y = (Screen.height - size.y) / 2 + offset.y;
                    break;
                case AnchorRelative.Up:
                    x = (Screen.width - size.x) / 2 + offset.x;
                    y = offset.y;
                    break;
                case AnchorRelative.Down:
                    x = (Screen.width - size.x) / 2 + offset.x;
                    y = Screen.height - size.y - offset.y;
                    break;
            }

            return new Rect(x, y, size.x, size.y);
        }

    }
}
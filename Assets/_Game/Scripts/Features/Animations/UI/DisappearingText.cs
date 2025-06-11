using TMPro;
using UnityEngine;

namespace _Game.Scripts.Features.Animations.UI
{
    public class DisappearingText: DisappearingUIElement
    {
        [SerializeField] private TextMeshProUGUI _text;
        protected override void SetOriginalColor() => OriginalColor = _text.color;
        protected override Color GetCurrentColor() => _text.color;
        protected override void SetColor(Color color) => _text.color = color;
        protected override void ResetColor() => _text.color = OriginalColor;
    }
}
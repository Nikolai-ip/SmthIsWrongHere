using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.Features.Animations.UI
{
    public class DisappearingImage: DisappearingUIElement
    {
        [SerializeField] private Image _image;
        protected override void SetOriginalColor() => OriginalColor = _image.color;
        protected override Color GetCurrentColor() => _image.color;
        protected override void SetColor(Color color) => _image.color = color;
        protected override void ResetColor() => _image.color = OriginalColor;
    }
}
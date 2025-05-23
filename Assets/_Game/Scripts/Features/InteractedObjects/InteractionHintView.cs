using UnityEngine;

namespace _Game.Scripts.Features.InteractedObjects
{
    public class InteractionHintView : MonoBehaviour
    {
        [SerializeField] private GameObject _hintView;

        public void ShowHint() => _hintView.SetActive(true);
        public void HideHint() => _hintView.SetActive(false);
    }
}
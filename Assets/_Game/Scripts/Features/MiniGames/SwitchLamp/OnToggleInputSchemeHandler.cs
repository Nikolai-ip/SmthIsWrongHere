using _Game.Scripts.Features.MiniGames.SwitchLamp.UI;
using UnityEngine;

namespace _Game.Scripts.Features.MiniGames.SwitchLamp
{
    public class OnToggleInputSchemeHandler:MonoBehaviour
    {
        [SerializeField] private Tutorial _scrollMouseTutorial;
        
        public void OnToggleInputScheme(InputScheme inputScheme)
        {
            if (inputScheme == InputScheme.MouseScroll)
                _scrollMouseTutorial.ShowTutorial();
        }
    }
}
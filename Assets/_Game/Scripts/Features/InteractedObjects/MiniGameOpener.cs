using _Game.Scripts.Core.MiniGame;
using _Game.Scripts.Features.MiniGames;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.InteractedObjects
{
    public class MiniGameOpener : BaseAction
    {
        [SerializeField] private MiniGameType _miniGameType;
        private MiniGamesService _miniGamesService;

        [Inject]
        public void Construct(MiniGamesService miniGamesService)
        {
            _miniGamesService = miniGamesService;
        }
        public override void Perform()
        {
            if (IsPerforming)
                return;
            
            IsPerforming = true;
            _miniGamesService.StartMiniGame(_miniGameType);
            IsPerforming = false;
        }
    }
}
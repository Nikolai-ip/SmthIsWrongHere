using _Game.Scripts.Core.MiniGame;
using _Game.Scripts.Features.InteractableSystem;
using _Game.Scripts.Features.MiniGames;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.InteractedObjects
{
    public class MiniGameOpener : InteractedMono
    {
        private MiniGamesService _miniGamesService;
        [SerializeField] private MiniGameType _miniGameType;

        [Inject]
        public void Construct(MiniGamesService miniGamesService)
        {
            _miniGamesService = miniGamesService;
        }
        public override void Interact(GameObject @this)
        {
            base.Interact(@this);
            _miniGamesService.StartMiniGame(_miniGameType);
        }
    }
}
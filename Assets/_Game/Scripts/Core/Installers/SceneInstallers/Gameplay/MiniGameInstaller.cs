using UnityEngine;
using Zenject;

namespace _Game.Scripts.Features.MiniGames
{
    public class MiniGameInstaller:MonoInstaller
    {
        [SerializeField] private MiniGameContext _context;

        public override void InstallBindings()
        {
            foreach (var miniGameContextApplier in GetComponentsInChildren<IMiniGameContextApplier>())
            {
                miniGameContextApplier.Apply(_context);
            }
            _context.Camera.enabled = false;
            _context.InputListener.Disable();
        }
    }
}
using System;
using System.Linq;
using _Game.Scripts.Common.Utilities;
using _Game.Scripts.Core.MiniGame;
using _Game.Scripts.Features.MiniGames;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Core.Installers.SceneInstallers.Gameplay
{
    public class MiniGameManagerInstaller:MonoInstaller
    {
        [SerializeField] private Camera _mainCamera;
        public override void InstallBindings()
        {
            var miniGames = ObjectsFinder
                .FindObjects<MiniGameContext>()
                .ToDictionary(key=> key.Type, value => value);
            var miniGameManager = new MiniGamesService(miniGames, _mainCamera);
            
            Container
                .Bind<MiniGamesService>()
                .FromInstance(miniGameManager)
                .AsSingle();
            Container
                .Bind<IDisposable>()
                .FromInstance(miniGameManager)
                .AsCached();
        }
    }
}
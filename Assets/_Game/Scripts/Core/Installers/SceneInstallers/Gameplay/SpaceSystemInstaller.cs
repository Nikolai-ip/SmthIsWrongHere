using System;
using _Game.Scripts.Core.SpaceSystem;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Core.Installers.SceneInstallers.Gameplay
{
    public class SpaceSystemInstaller:MonoInstaller
    {
        [SerializeField] private int _initialFloorNumber;
        [SerializeField] private FloorRoomTransitions[] _floorRoomTransitions;
        [SerializeField] private Transform _characterTr;
        public override void InstallBindings()
        {
            var roomContainer = new RoomContainer();
            var transitionApplier = new RoomTransitionApplier(_characterTr, Camera.main);
            var roomTransitionService = new RoomTransitionsManager(roomContainer, _floorRoomTransitions, transitionApplier);
            roomTransitionService.SetFloor(_initialFloorNumber);
            Container
                .Bind<RoomContainer>()
                .FromInstance(roomContainer)
                .AsSingle();
            Container
                .Bind<IDisposable>()
                .FromInstance(roomTransitionService)
                .AsCached();
            Container
                .Bind<RoomTransitionsManager>()
                .FromInstance(roomTransitionService)
                .AsSingle();
        }
    }
}
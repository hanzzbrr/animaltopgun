using UnityEngine;
using Zenject;
using HypaGames.LevelGeneration;

namespace HypaGames.AnimalTopGun
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayArea _playArea;

        public override void InstallBindings()
        {
            Container.Bind<IPlayArea>().FromInstance(_playArea).AsSingle().NonLazy();
        }
    }
}
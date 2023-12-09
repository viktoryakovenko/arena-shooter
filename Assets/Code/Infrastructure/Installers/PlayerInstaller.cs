using Code.Hero;
using Code.StaticData;
using System;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private GameObject _heroPrefab;

        public override void InstallBindings()
        {
            BindStats();
            BindMovement();
        }

        private void BindStats()
        {
            Container
                .Bind<HeroStaticData>()
                .FromScriptableObjectResource("StaticData/Hero/HeroData")
                .AsSingle()
                .NonLazy();
        }

        private void BindMovement()
        {
            HeroMovement heroMovement = Container
                            .InstantiatePrefabForComponent<HeroMovement>(_heroPrefab, _startPoint.position, Quaternion.identity, null);

            Container
                .Bind<HeroMovement>()
                .FromInstance(heroMovement)
                .NonLazy();
        }
    }
}
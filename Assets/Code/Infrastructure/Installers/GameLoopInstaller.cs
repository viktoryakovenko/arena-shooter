using Code.Hero;
using Code.StaticData;
using UnityEngine;
using Zenject;
using Code.Infrastructure.Factory;

namespace Code.Infrastructure.Installers
{
    public class GameLoopInstaller : MonoInstaller
    {
        [SerializeField] private Transform _startPoint;

        public override void InstallBindings()
        {
            BindStats();

            BindFactory();
            BindPlayer();
            BindUI();
        }

        private void BindPlayer()
        {
            var instantiatedHero = Container
                .Resolve<GameFactory>()
                .CreateHero(_startPoint);

            Container
                .Bind<HeroMovement>()
                .FromInstance(instantiatedHero.GetComponent<HeroMovement>())
                .AsSingle();
        }

        private void BindUI()
        {
            Container
                .Resolve<GameFactory>()
                .CreateHud();
        }

        private void BindFactory()
        {
            Container
                .Bind<GameFactory>()
                .AsSingle();
        }

        private void BindStats()
        {
            Container
                .Bind<HeroStaticData>()
                .FromScriptableObjectResource("StaticData/Hero/HeroData")
                .AsSingle()
                .NonLazy();
        }
    }
}
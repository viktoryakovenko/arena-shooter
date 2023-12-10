using Code.Hero;
using Code.StaticData;
using UnityEngine;
using Zenject;
using Code.Infrastructure.Factory;
using Code.Logic;

namespace Code.Infrastructure.Installers
{
    public class GamePlayInstaller : MonoInstaller
    {
        [SerializeField] private Transform _startPoint;

        public override void InstallBindings()
        {
            BindStats();

            BindFactory();
            BindPlayer();
        }

        private void BindPlayer()
        {
            var hero = Container.Resolve<GameFactory>().CreateHero(_startPoint);

            BindUIForPlayer(hero.GetComponent<IHealth>(), hero.GetComponent<IPower>());

            var instantiatedHero = Container.InstantiatePrefab(hero);

            Container
                .Bind<HeroMovement>()
                .FromInstance(instantiatedHero.GetComponent<HeroMovement>())
                .AsSingle()
                .NonLazy();

        }

        private void BindUIForPlayer(IHealth health, IPower power)
        {
            var hud = Container.Resolve<GameFactory>().CreateHud(health, power);
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
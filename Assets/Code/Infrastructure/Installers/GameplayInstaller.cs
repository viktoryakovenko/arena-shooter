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
            BindUI();
        }

        private void BindUI()
        {
            var heroHealth = Container.Resolve<HeroMovement>().GetComponent<IHealth>();
            var heroPower = Container.Resolve<HeroMovement>().GetComponent<IPower>();
            var hud = Container.Resolve<GameFactory>().CreateHud(heroHealth);

            var instantiatedHud = Container.InstantiatePrefab(hud);
        }

        private void BindPlayer()
        {
            var hero = Container.Resolve<GameFactory>().CreateHero(_startPoint);

            var instantiatedHero = Container.InstantiatePrefab(hero);

            Container
                .Bind<HeroMovement>()
                .FromInstance(instantiatedHero.GetComponent<HeroMovement>())
                .AsSingle()
                .NonLazy();
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
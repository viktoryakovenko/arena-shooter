using Code.Hero;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private GameBootstraper _bootstraper;

        public override void InstallBindings()
        {
            BindGameBootsrapper();
            BindInput();
        }

        private void BindGameBootsrapper()
        {
            GameBootstraper gameBootstraper = Container
                .InstantiatePrefabForComponent<GameBootstraper>(_bootstraper);

            Container
                .BindInstance<GameBootstraper>(gameBootstraper)
                .AsSingle();
        }

        private void BindInput()
        {
            Container.Bind<HeroMovement>().AsSingle();
        }
    }
}
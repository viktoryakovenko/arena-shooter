using Zenject;

namespace Code.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputActions>().AsSingle().NonLazy();
        }
    }
}
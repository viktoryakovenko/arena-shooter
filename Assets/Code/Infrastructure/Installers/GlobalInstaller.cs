using Zenject;

namespace Code.Infrastructure.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInput();
        }

        private void BindInput()
        {
            Container
                .Bind<InputActions>()
                .AsSingle()
                .NonLazy();
        }
    }
}
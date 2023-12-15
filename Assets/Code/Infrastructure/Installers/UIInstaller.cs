using Code.Infrastructure.Factory;
using Code.Logic;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindUI();
            BindScoreCount();
        }

        private void BindUI()
        {
            Container
                .Resolve<GameFactory>()
                .CreateHud();
        }

        private void BindScoreCount()
        {
            Container.Bind<TotalScore>().AsSingle();
        }
    }
}
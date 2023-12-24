using Code.Logic;
using Code.Infrastructure.Factory;
using Code.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class EnemiesInstaller : MonoInstaller
    {
        [SerializeField] private SpawnerStaticData _spawnerStaticData;

        public override void InstallBindings()
        {
            Container.Bind<EnemyStaticDataService>().AsSingle();

            Container.Bind<EnemyFactory>().AsSingle();
            Container.Bind<EnemyCollection>().AsSingle();

            Container.Bind<SpawnerStaticData>().FromInstance(_spawnerStaticData);

            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle();
        }
    }
}
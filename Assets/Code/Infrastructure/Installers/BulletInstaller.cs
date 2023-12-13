using Code.Infrastructure.Factory;
using Code.Logic;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BulletInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _bulletPrefab;

        public override void InstallBindings()
        {
            Container.Bind<BulletFactory>().AsSingle();

            Container.Bind<BulletSpawner>().AsSingle();
        }
    }
}

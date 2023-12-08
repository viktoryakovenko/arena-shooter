using Code.Inputs;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private GameObject _heroPrefab;

        public override void InstallBindings()
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
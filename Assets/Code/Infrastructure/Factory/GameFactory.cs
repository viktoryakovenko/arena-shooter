using Code.Hero;
using Code.Infrastructure.AssetManagment;
using Code.Inputs;
using Code.Logic;
using Code.StaticData;
using Code.UI;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly HeroStaticData _heroData;
        private readonly DiContainer _diContainer;

        private GameObject _hero;
        private GameObject _hud;

        public GameFactory(HeroStaticData heroData, DiContainer container)
        {
            _heroData = heroData;
            _diContainer = container;
        }

        public GameObject CreateHero(Transform at)
        {
            GameObject heroGameObject = Resources.Load<GameObject>(AssetPath.HeroPath);
            _hero = _diContainer.InstantiatePrefab(heroGameObject, at.position, Quaternion.identity, null);

            IHealth health = _hero.GetComponent<IHealth>();
            health.Current = _heroData.MaxHealth;
            health.Max = _heroData.MaxHealth;

            IPower power = _hero.GetComponent<IPower>();
            power.Current = _heroData.CurrentPower;
            power.Max = _heroData.MaxPower;

            _hero.GetComponent<HeroAttack>().Damage = _heroData.Damage;

            _hero.GetComponent<HeroMovement>().MovementSpeed = _heroData.MoveSpeed;
            _hero.GetComponent<CameraRotationHandler>().Sensitivity = _heroData.Sensitivity;

            return _hero;
        }

        public GameObject CreateHud()
        {
            GameObject hudGameObject = Resources.Load<GameObject>(AssetPath.HudPath);
            _hud = _diContainer.InstantiatePrefab(hudGameObject);

            _hud.GetComponent<ActorHpUI>().Construct(_hero.GetComponent<IHealth>());
            _hud.GetComponent<ActorPowerUI>().Construct(_hero.GetComponent<IPower>());

            return _hud;
        }
    }
}
using Code.Hero;
using Code.Logic;
using UnityEngine;
using Zenject;

namespace Code.Enemy
{
    [RequireComponent(typeof(EnemyDeath))]
    public class PowerForKill : MonoBehaviour
    {
        public float PowerPoints;

        private IPower _heroPower;

        [Inject]
        private void Construct(HeroMovement heroMovement)
        {
            _heroPower = heroMovement.GetComponent<IPower>();
        }

        private void OnEnable()
        {
            GetComponent<EnemyDeath>().Happened += AddPowerToHero;
        }

        private void OnDisable()
        {
            GetComponent<EnemyDeath>().Happened -= AddPowerToHero;
        }

        private void AddPowerToHero()
        {
            _heroPower.AddPower(PowerPoints);
        }
    }
}
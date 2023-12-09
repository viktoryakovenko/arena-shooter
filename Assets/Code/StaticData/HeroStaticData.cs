using UnityEngine;

namespace Code.StaticData
{
    [CreateAssetMenu(fileName = "HeroData", menuName = "StaticData/HeroStats")]
    public class HeroStaticData : ScriptableObject
    {
        [Range(50f, 100f)]
        public float Sensitivity;

        [Range(0.5f, 5f)]
        public float MoveSpeed;

        [Range(0f, 100f)]
        public float MaxHealth;

        [Range(10f, 50f)]
        public float Damage;

        [Range(0f, 100f)]
        public int MaxPower;

        [Range(0f, 100f)]
        public float CurrentPower;
    }
}
using UnityEngine;

namespace Code.StaticData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyTypeId EnemyTypeId;

        [Range(1, 10)]
        public int SpawnWeight;

        [Range(0.5f, 5.0f)]
        public float MoveSpeed;

        [Range(0f, 50f)]
        public float Damage;

        [Range(1, 100)]
        public float Hp;

        [Min(0)]
        public int PowerPoints;

        public GameObject Prefab;
    }
}
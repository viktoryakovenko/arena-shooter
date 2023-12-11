using System.Collections.Generic;
using UnityEngine;

namespace Code.StaticData
{
    [CreateAssetMenu(fileName = "SpawnerData", menuName = "StaticData/Spawner")]
    public class SpawnerStaticData : ScriptableObject
    {
        public List<Transform> SpawnPoints;

        [Range(1f, 10f)]
        public float SpawnInterval;

        [Range(1f, 10f)]
        public float MaxSpawnInterval;

        [Range(0, 50)]
        public int MaxSize;
    }
}
using UnityEngine;

namespace Assets.Code.Logic
{
    public interface ISpawner
    {
        GameObject Spawn(Vector3 spawnPoint);
    }
}

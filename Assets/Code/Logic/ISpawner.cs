using UnityEngine;

namespace Code.Logic
{
    public interface ISpawner
    {
        GameObject Spawn(Vector3 spawnPoint);
    }
}

using UnityEngine;

namespace Assets.Code.Logic
{
    public interface ISpawner
    {
        void Spawn(Vector3 position, Transform parent = null);
    }
}

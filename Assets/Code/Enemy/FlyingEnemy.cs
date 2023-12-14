using System.Collections;
using UnityEngine;

namespace Code.Enemy
{
    [AddComponentMenu("Enemy/Flying")]
    public class FlyingEnemy : MonoBehaviour
    {
        [SerializeField] private float _freezeTime;
        [SerializeField] private float _flyHeight;

        private void Start()
        {

        }

        private IEnumerator FlyRoutine()
        {
            //var aimY = transform.position.y + _flyHeight;
            //Vector3 endPoint = aimY;
            yield return null;

            StartCoroutine(WaitRoutine());
        }

        private IEnumerator WaitRoutine()
        {
            yield return new WaitForSecondsRealtime(_freezeTime);
        }
    }
}
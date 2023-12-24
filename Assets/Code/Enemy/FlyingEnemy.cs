using System.Collections;
using UnityEngine;

namespace Code.Enemy
{
    [AddComponentMenu("Enemy/Flying")]
    [RequireComponent(typeof(MoveToPlayer))]
    public class FlyingEnemy : MonoBehaviour
    {
        [SerializeField] private float _freezeTime;
        [SerializeField] private float _flyHeight;

        private float _moveSpeed;
        private MoveToPlayer _moveToPlayer;

        private void Start()
        {
            _moveToPlayer = GetComponent<MoveToPlayer>();
            _moveSpeed = _moveToPlayer.MoveSpeed;
            _moveToPlayer.enabled = false;

            StartCoroutine(FlyRoutine());
        }

        private IEnumerator FlyRoutine()
        {
            var aimY = transform.position.y + _flyHeight;
            Vector3 endPoint = new Vector3(transform.position.x, aimY, transform.position.z);

            while (transform.position != endPoint)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPoint, _moveSpeed * Time.deltaTime);
                yield return null;
            }

            StartCoroutine(WaitRoutine());
        }

        private IEnumerator WaitRoutine()
        {
            yield return new WaitForSecondsRealtime(_freezeTime);
            _moveToPlayer.enabled = true;
        }
    }
}
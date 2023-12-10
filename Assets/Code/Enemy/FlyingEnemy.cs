using DG.Tweening;
using UnityEngine;

namespace Code.Enemy
{
    [RequireComponent(typeof(MoveToPlayer))]
    public class FlyingEnemy : MonoBehaviour
    {
        [SerializeField] private float _freezeTime;
        [SerializeField] private float _flyHeight;

        private MoveToPlayer _moveToPlayer;

        private void Awake()
        {
            _moveToPlayer = GetComponent<MoveToPlayer>();
        }

        private void Start()
        {
            transform
                .DOMoveY(transform.position.y + _flyHeight, _moveToPlayer.MoveSpeed)
                .SetSpeedBased()
                .SetEase(Ease.Linear)
                .OnComplete(Wait);

        }

        private void Wait()
        {
            DOTween
                .Sequence()
                .SetDelay(_freezeTime)
                .OnComplete(() => Destroy(this));
        }
    }
}
using DG.Tweening;
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
            transform
                .DOMoveY(transform.position.y + _flyHeight, 0.01f)
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
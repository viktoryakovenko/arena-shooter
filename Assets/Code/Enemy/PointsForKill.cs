using Code.Logic;
using UnityEngine;
using Zenject;

namespace Code.Enemy
{
    [RequireComponent(typeof(EnemyDeath))]
    public class PointsForKill : MonoBehaviour
    {
        private TotalScore _totalScore;

        [Inject]
        private void Construct(TotalScore totalScore)
        {
            _totalScore = totalScore;
        }

        private void OnEnable()
        {
            GetComponent<EnemyDeath>().Happened += _totalScore.AddPoint;
        }

        private void OnDisable()
        {
            GetComponent<EnemyDeath>().Happened -= _totalScore.AddPoint;
        }
    }
}
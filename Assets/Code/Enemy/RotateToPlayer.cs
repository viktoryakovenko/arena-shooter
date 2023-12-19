using Code.Hero;
using UnityEngine;
using Zenject;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _heroTransform;
    private Vector3 _positionToLook;

    [Inject]
    private void Construct(HeroMovement heroMovement) =>
        _heroTransform = heroMovement.transform;

    private void Update()
    {
        if (Initialized())
            RotateTowardsHero();
    }

    private void RotateTowardsHero()
    {
        UpdatePositionToLookAt();

        transform.rotation = SmoothedRotation(transform.rotation, _positionToLook);
    }

    private void UpdatePositionToLookAt()
    {
        Vector3 positionDifference = _heroTransform.position - transform.position;
        _positionToLook = new Vector3(positionDifference.x, 0, positionDifference.z);
    }

    private Quaternion SmoothedRotation(Quaternion rotation, Vector3 positionToLook) =>
        Quaternion.Lerp(rotation, TargetRotation(positionToLook), SpeedFactor());

    private Quaternion TargetRotation(Vector3 positionToLook) =>
        Quaternion.LookRotation(positionToLook);

    private float SpeedFactor() =>
        _speed * Time.deltaTime;

    private bool Initialized() =>
            _heroTransform != null;
}

using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private BulletsPool _bulletsPool;
    [SerializeField] private GameObject _flashEffect;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private Turret _turret;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeDelay;
    [SerializeField] private float _radius;

    private void Awake()
    {
        _turret.SetPattern(new IdlePattern(_turret.transform, _speed, _timeDelay));
    }

    private void Update()
    {
        TurretBehaviour();
    }

    private void TurretBehaviour()
    {
        Collider[] colliders = Physics.OverlapSphere(_turret.transform.position, _radius);
        var foundRocket = false;
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out RocketThrust rocket))
            {
                _turret.SetPattern(new AttackPattern(_turret.transform, rocket.transform, _timeDelay, _muzzle, _bulletPrefab, _flashEffect, _bulletsPool));
                foundRocket = true;
            }
        }
        if (!foundRocket)
            _turret.SetPattern(new IdlePattern(_turret.transform, _speed, _timeDelay));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_turret.transform.position, _radius);
    }
}

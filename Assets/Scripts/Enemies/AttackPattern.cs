using System;
using System.Threading.Tasks;
using UnityEngine;

public class AttackPattern : ITurretStrategy
{
    private Transform _muzzle;
    private GameObject _prefab;
    private GameObject _flashEffect;
    private Transform _transform;
    private Transform _target;
    private float _timer;
    private float _timeDelay;
    private bool _canMove;

    private float _duration = 0.4f;

    public AttackPattern(Transform transform, Transform target, float timeDelay, Transform muzzle, GameObject prefab, GameObject flashEffect)
    {
        _transform = transform;
        _target = target;
        _timeDelay = timeDelay;
        _muzzle = muzzle;
        _prefab = prefab;
        _flashEffect = flashEffect;
    }

    public async Task StartMove()
    {
        await LookRotation(_duration, () => _target.position - _transform.position);

        _canMove = true;
    }

    private async Task LookRotation(float duration, Func<Vector3> direction)
    {
        var fromRotation = _transform.rotation;
        var elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            var t = elapsedTime / duration;
            var slerp = Quaternion.Slerp(fromRotation, Quaternion.LookRotation(direction.Invoke()), t);
            _transform.rotation = slerp;
            elapsedTime += Time.deltaTime;
            await Task.Yield();
        }
    }

    public async Task StopMove()
    {
        await LookRotation(_duration / 3f, () => Vector3.back);

        _canMove = false;
    }

    public void Update(float deltaTime)
    {
        Shoot();
    }

    private void Shoot()
    {
        _timer += Time.deltaTime;
        _transform.LookAt(_target);
        if (_timer >= _timeDelay)
        {
            _timer = 0;
            Debug.Log("Shot");
            GameObject flashEffect = UnityEngine.Object.Instantiate(_flashEffect);
            flashEffect.transform.rotation = _muzzle.transform.rotation;
            flashEffect.transform.position = _muzzle.transform.position;
            GameObject bullet = UnityEngine.Object.Instantiate(_prefab);
            bullet.transform.position = _muzzle.transform.position;
            bullet.transform.rotation = _muzzle.rotation;
        }
    }
}
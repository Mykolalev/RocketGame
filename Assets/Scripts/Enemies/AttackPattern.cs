using System;
using System.Threading.Tasks;
using UnityEngine;

public class AttackPattern : ITurretStrategy
{
    private Transform _transform;
    private Transform _target;
    private float _timer;
    private float _timeDelay;
    private bool _canMove;

    private float _duration = 0.4f;

    public AttackPattern(Transform transform, Transform target, float timeDelay)
    {
        _transform = transform;
        _target = target;
        _timeDelay = timeDelay;
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
        }
    }
}
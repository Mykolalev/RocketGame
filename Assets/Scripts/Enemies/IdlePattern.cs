using System.Threading.Tasks;
using UnityEngine;

public class IdlePattern : ITurretStrategy
{
    private Transform _transform;
    private float _speed;
    private bool _canMove;
    private float _timer;
    private float _timeDelay;
    private float _maxRotationX = 5;
    private float _minRotationX = -90;
    private Vector3 _newRotation;

    public IdlePattern(Transform transform, float speed, float timeDelay)
    {
        _transform = transform;
        _speed = speed;
        _timeDelay = timeDelay;
    }

    public Task StartMove()
    {
        _canMove = true;
        return Task.CompletedTask;
    }
    public Task StopMove()
    {
        _canMove = false;
        return Task.CompletedTask;
    }

    public void Update(float deltaTime)
    {
        _timer += deltaTime * (_speed / 100f);
        if (_timer >= _timeDelay)
        {
            _newRotation = SwitchTargetRotation();
            _timer = 0;
        }
        
        Quaternion targetRotation = Quaternion.Euler(_newRotation);
        _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, Mathf.InverseLerp(0, _timeDelay, _timer));
    }

    private Vector3 SwitchTargetRotation()
    {
        Vector3 newRotation = new Vector3(Random.Range(_minRotationX, _maxRotationX), Random.Range(0, 360), 0);
        return newRotation;
    }
}


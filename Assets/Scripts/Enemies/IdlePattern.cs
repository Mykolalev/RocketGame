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

    public IdlePattern(Transform transform, float speed, float timeDelay)
    {
        _transform = transform;
        _speed = speed;
        _timeDelay = timeDelay;
    }

    public async Task StartMove()
    {
        await Task.Delay(2000);
        _canMove = true;
    }
    public async Task StopMove()
    {
        await Task.Delay(2000);
        _canMove = false;
    }

    public void Update(float deltaTime)
    {
        _timer += deltaTime;
        if (_timer >= _timeDelay)
        {
            Debug.Log("Im changing pos");
            Vector3 newRotation = SwitchTargetRotation();
            Quaternion targetRotation = Quaternion.Euler(newRotation);
            Quaternion newQuaternion = Quaternion.Slerp(_transform.rotation, targetRotation, (_speed / _timeDelay) * deltaTime);
            _transform.rotation = newQuaternion;
            //_transform.Rotate(newRotation * _speed * deltaTime);
            _timer = 0;
        }
    }

    private Vector3 SwitchTargetRotation()
    {
        Vector3 newRotation = new Vector3(Random.Range(_minRotationX, _maxRotationX), Random.Range(0, 360), 0);
        return newRotation;
    }
}


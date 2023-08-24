using UnityEngine;

public class IdlePattern : ITurretStrategy
{
    private Transform _transform;
    private float _speed;
    private bool _canMove;
    private float _timer;
    private float _timeDelay;
    private float _maxRotationX = 5;
    private float _minRotationX= -90;

    public IdlePattern(Transform transform, float speed, float timeDelay)
    {
        _transform = transform;
        _speed = speed;
        _timeDelay = timeDelay;
    }

    public void StartMove() => _canMove = true;
    public void StopMove() => _canMove = false; 

    public void Update(float deltaTime)
    {
        _timer += deltaTime;
        if (_timer >= _timeDelay)
        {
            _timer = 0;
            Vector3 newRotation = SwitchTargetRotation();
            Debug.Log("Im changing pos");
            _transform.Rotate(newRotation * _speed * deltaTime);
        }
    }

    private Vector3 SwitchTargetRotation()
    {
        Vector3 newRotation = new Vector3(Random.Range(_minRotationX, _maxRotationX), Random.Range(0, 360), 0);
        return newRotation;
    }
}

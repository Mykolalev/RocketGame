using System.Threading.Tasks;
using UnityEngine;

public class AttackPattern : ITurretStrategy
{
    private Transform _transform;
    private Transform _target;
    private float _timer;
    private float _timeDelay;
    private bool _canMove;

    public AttackPattern(Transform transform, Transform target, float timeDelay)
    {
        _transform = transform;
        _target = target;
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

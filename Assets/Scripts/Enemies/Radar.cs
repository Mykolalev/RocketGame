using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _radius;
    [SerializeField] private float _rotatingSpeed;
    private bool _targetDetected = false;

    public bool TargetDetected => _targetDetected;  

    void Update()
    {        
        RotateRadar();
    }

    private void LookingForPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
        foreach (Collider collider in colliders)
        {
            if(collider.TryGetComponent<Movement>(out var movement))
            {
                _targetDetected = true;
            }
            else
            {
                _targetDetected = false;
            }
        }
    }

    private void RotateRadar()
    {
        transform.Rotate(0, _rotatingSpeed, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}

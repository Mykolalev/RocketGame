using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private Vector3 _movementVector;
    [SerializeField] [Range(0,1)] private float _movementFactor;
    [SerializeField] private float _period = 2f;
    private const float TAU = Mathf.PI * 2;
    private Vector3 _startPosition;
    
    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_period == 0) { return; }

        float cycle = Time.time / _period;
        
        float sinWave = Mathf.Sin(cycle * TAU);

        _movementFactor = (sinWave + 1f) / 2f;

        Vector3 offset = _movementVector * _movementFactor;
        transform.position = _startPosition + offset;
    }
}

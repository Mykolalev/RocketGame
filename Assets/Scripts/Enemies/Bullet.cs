using UnityEngine;

public class Bullet : Obstacle
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _explosionEffect; 

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(_explosionEffect, transform.position, Quaternion.Euler(-transform.forward));
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        transform.position += transform.forward * _speed;
    }

}

using System;
using UnityEngine;

public class Bullet : Obstacle
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _explosionEffect;

    public event Action<Bullet> Destroyed;

    private void Start()
    {
        Invoke(nameof(InvokeAction), 2f);
    }

    void FixedUpdate()
    {
        transform.position += transform.forward * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(_explosionEffect, transform.position, Quaternion.Euler(-transform.forward));
        Destroyed?.Invoke(this);
    }

    private void InvokeAction()
    {
        Destroyed?.Invoke(this);
    }
}

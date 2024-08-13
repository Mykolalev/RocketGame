using System;
using UnityEngine;

public class Bullet : Obstacle
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _collider;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private float _lifeTime;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _clip;

    public event Action<Bullet> Destroyed;

    private void OnEnable()
    {
        Invoke(nameof(InvokeAction), _lifeTime);
    }

    public void BulletFly(Transform muzzle)
    {
        _rb.velocity = muzzle.forward * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(_explosionEffect, transform.position, Quaternion.Euler(-transform.forward));
        Destroyed?.Invoke(this);
        PlaySound();
        Deactivate();
    }

    private void InvokeAction()
    {
        Destroyed?.Invoke(this);
        Deactivate();
    }

    public void Activate()
    {
        _renderer.enabled = true;
        _collider.enabled = true;
    }

    private void Deactivate()
    {
        _renderer.enabled = false;
        _collider.enabled = false;
    }

    private void PlaySound()
    {
        if (!_source.isPlaying)
            _source.PlayOneShot(_clip);
    }
}

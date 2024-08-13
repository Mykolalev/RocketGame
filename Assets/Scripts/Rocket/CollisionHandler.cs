using Assets.Scripts;
using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _crashParticles;
    [SerializeField] private ParticleSystem _winParticles;
    [SerializeField] private ParticleSystem _collectAnItemParticles;

    public event Action Dead;
    public event Action Finished;
    public event Action GotAnItem; 
     
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Finish>())
        {
            _winParticles.Play();
            Finished?.Invoke();
            DisableMovement();
            LevelOpener.UnlockLevel();
        }

        if (collision.collider.GetComponent<Obstacle>())
        {
            _crashParticles.Play();
            Dead?.Invoke();
            DisableMovement();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>())
        {
            Debug.Log("Hit the barrel");
            _collectAnItemParticles.Play();
            GotAnItem?.Invoke();
        }
    }

    private void DisableMovement()
    {
        transform.GetComponent<Movement>().enabled = false;
    }
}
using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action Dead;
    public event Action Finished;

    private bool _gotHit = false;
    private bool _cheatOn = false;

    public bool CheatOn
    {
        get => _cheatOn;
        set
        {
            _cheatOn = value;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( _gotHit || _cheatOn) { return; }

        if (collision.collider.TryGetComponent<IWinable>(out var winable))
        {
            _gotHit = true;
            winable.Win(Finished, transform);
            DisableMovement();
        }
        else if (collision.collider.TryGetComponent<IDeadable>(out var deadable))
        {
            _gotHit = true;
            deadable.Dead(Dead, transform);
            DisableMovement();
        }
    }

    private void DisableMovement()
    {
        transform.GetComponent<Movement>().enabled = false;
    }
}

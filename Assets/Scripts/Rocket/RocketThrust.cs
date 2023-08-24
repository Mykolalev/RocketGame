using UnityEngine;

public class RocketThrust : MonoBehaviour
{
    [SerializeField] private ParticleSystem _thrustingFire;
    private Movement _movement;

    void Start()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        PlayParticle();          
    }

    void PlayParticle()
    {
        if (_movement.CanPush)
        {
            if(!_thrustingFire.isPlaying)
                _thrustingFire.Play();
        }
        else
        {
            _thrustingFire.Stop();
        }
    }
}

using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioClip _thrustingClip;
    [SerializeField] private AudioClip _deathClip;
    [SerializeField] private AudioClip _winClip;
    private CollisionHandler _collisionHandler;
    private AudioSource _audioSource;
    private Movement _movement;

    private void Start()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _collisionHandler.Dead += PlayDeathSound;
        _collisionHandler.Finished += PlayFinishedSound;
        _audioSource = GetComponent<AudioSource>();
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        PlayThurstSound();
    }

    private void PlayThurstSound()
    {
        if (_movement.CanPush == true && !_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_thrustingClip);
        }
        else if (Input.GetKeyUp(KeyCode.Space) && _audioSource.isPlaying) //_movement.CanPush == false && _audioSource.isPlaying
        {
            _audioSource.Stop();
        }
    }

    private void PlayDeathSound()
    {
        Debug.Log("DeathSound");
        _audioSource.Stop();
        _audioSource.PlayOneShot(_deathClip);

    }

    private void PlayFinishedSound()
    {
        Debug.Log("WinSound");
        _audioSource.Stop();
        _audioSource.PlayOneShot(_winClip);
    }
}

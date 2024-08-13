using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource _mainAudioSource;
    [SerializeField] private AudioSource _effectsAudioSource;

    [SerializeField] private AudioClip _thrustingClip;
    [SerializeField] private AudioClip _deathClip;
    [SerializeField] private AudioClip _winClip;
    [SerializeField] private AudioClip _gotAnIClip;

    private CollisionHandler _collisionHandler;
    private Movement _movement;

    private void Start() 
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _collisionHandler.Dead += PlayDeathSound;
        _collisionHandler.Finished += PlayFinishedSound;
        _collisionHandler.GotAnItem += OnGotAnItem;
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        PlayThurstSound();
    }

    private void PlayThurstSound()
    {
        if (_movement.CanPush == true && !_mainAudioSource.isPlaying)
        {
            _mainAudioSource.PlayOneShot(_thrustingClip);
        }
        else if (_movement.CanPush == false/*Input.GetKeyUp(KeyCode.Space)*/ && _mainAudioSource.isPlaying)
        {
            _mainAudioSource.Stop();
        }
    }

    private void PlayDeathSound()
    {
        if (!_effectsAudioSource.isPlaying)
            _effectsAudioSource.PlayOneShot(_deathClip);
    }

    private void PlayFinishedSound()
    {
        if (!_effectsAudioSource.isPlaying)
            _effectsAudioSource.PlayOneShot(_winClip);
    }

    private void OnGotAnItem()
    {
        if (!_effectsAudioSource.isPlaying)
            _effectsAudioSource.PlayOneShot(_gotAnIClip);
    }
}

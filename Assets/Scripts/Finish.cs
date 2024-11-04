using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private ParticleSystem _finishParticles;
    private string _levelPrefsName = PrefsContainer.LevelPrefName;

    private void OnCollisionEnter(Collision collision)
    {
        CollisionHandler player = collision.collider.GetComponent<CollisionHandler>();

        if (player != null)
        {
            UnlockLevel();
            _finishParticles.Play();
            Debug.Log(PlayerPrefs.GetInt(_levelPrefsName));
        }
    }

    private void UnlockLevel()
    {
        LevelOpener.UnlockLevel();
    }
}
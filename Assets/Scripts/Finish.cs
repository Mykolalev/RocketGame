using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private ParticleSystem _finishParticles;
    private string _levelPrefsName = PrefsContainer.LevelPrefsName;

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
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt(_levelPrefsName))
        {
            PlayerPrefs.SetInt(_levelPrefsName, currentLevel + 1);
        }
    }
}
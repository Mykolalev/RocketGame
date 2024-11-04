using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProcess : MonoBehaviour
{
    [SerializeField] private CollisionHandler _collisionHandler;

    private void Start()
    {
        _collisionHandler.Dead += ReloadWithDelay;
        _collisionHandler.Finished += NextLevelWithDelay;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentScene + 1;
        if(nextLevel == SceneManager.sceneCountInBuildSettings)
        {
            nextLevel = 0;
        }

        SceneManager.LoadScene(nextLevel);
    }

    private void NextLevelWithDelay()
    {
        DisableComponents();
        Invoke(nameof(NextLevel),1f);
    }

    private void ReloadWithDelay()
    {
        DisableComponents();
        Invoke(nameof(ReloadScene), 1f);
    }

    private void DisableComponents()
    {
        _collisionHandler.GetComponent<Movement>().enabled = false;
    }
}
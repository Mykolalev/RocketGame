using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheat : MonoBehaviour
{
    [SerializeField] private CollisionHandler _collisionHandler;

    private void Update()
    {
        CheatOnAndOff();
        NextLevel();
    }

    private void CheatOnAndOff()
    {
        if (Input.GetKeyDown(KeyCode.C))
            _collisionHandler.CheatOn = !_collisionHandler.CheatOn;
    }

    private void NextLevel()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            int nextLevel = currentLevel + 1;
            if (nextLevel == SceneManager.sceneCountInBuildSettings)
            {
                nextLevel = 0;
            }
            SceneManager.LoadScene(nextLevel);
        }
    }
}
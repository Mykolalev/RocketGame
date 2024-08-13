using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private const string LevelsPrefsName = "Levels";
    public void PlayGame()
    {
        int level = PlayerPrefs.GetInt(LevelsPrefsName);
        SceneManager.LoadScene(level);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    { 
        Application.Quit();
    }
}

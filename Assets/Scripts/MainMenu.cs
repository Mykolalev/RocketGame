using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        int level = PlayerPrefs.GetInt("levels");
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

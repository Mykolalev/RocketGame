using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string _levelsPrefsName = PrefsContainer.LevelPrefName;

    public void PlayGame()
    {
        int level = DefineLevel();
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

    private int DefineLevel()
    {
        int level = PlayerPrefs.GetInt(_levelsPrefsName);
        if (level == 0)       
            level++;
        
        return level;
    }
}
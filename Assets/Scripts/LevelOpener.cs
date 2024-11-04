using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelOpener
{ 
    private static string _levelPrefs = PrefsContainer.LevelPrefName;

    public static void UnlockLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt(_levelPrefs))
        {
            PlayerPrefs.SetInt(_levelPrefs, currentLevel + 1);
        }
    }
}
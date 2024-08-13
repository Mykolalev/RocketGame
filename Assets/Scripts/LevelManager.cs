using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] _levels;

    private const string LevelsPrefsName = "Levels";

    public static LevelManager Instance;
    public int LevelUnlock;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
        LevelUnlock = PlayerPrefs.GetInt(LevelsPrefsName, 1);

        for (int i = 0; i < _levels.Length; i++)
        {
            _levels[i].interactable = false;
        }

        for (int i = 0; i < LevelUnlock; i++)
        {
            _levels[i].interactable = true;
        }
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
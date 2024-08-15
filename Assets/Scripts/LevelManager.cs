using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] _levels;
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _menuPanel; 
    [SerializeField] private GameObject _loadPanel;

    private string LevelPrefsName = PrefsContainer.LevelPrefsName;

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
        Debug.Log(PlayerPrefs.GetInt(LevelPrefsName));
        LevelUnlock = PlayerPrefs.GetInt(LevelPrefsName, 1);

        for (int i = 0; i < _levels.Length; i++)
        {
            _levels[i].interactable = false;
        }

        for (int i = 0; i < LevelUnlock; i++)
        {
            _levels[i].interactable = true;
        }
    }

    public void LoadLevelButton(int index) 
    {
        _menuPanel.SetActive(false); 
        _loadPanel.SetActive(true);

        StartCoroutine(LoadLevel(index));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);

        while (!operation.isDone)  
        {
            float operationProgressValue = operation.progress;
            _slider.value = operationProgressValue;
            yield return null;
        }
    }
}
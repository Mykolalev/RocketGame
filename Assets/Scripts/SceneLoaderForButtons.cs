using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoaderForButtons : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _menuPanel; 
    [SerializeField] private GameObject _loadPanel;

    public void LoadLevelButton(int index) 
    {
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
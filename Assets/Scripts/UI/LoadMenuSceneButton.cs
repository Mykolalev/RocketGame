using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMenuSceneButton : MonoBehaviour
{
    [SerializeField] private Button _toMenuButton;

    private void Start()
    {
        _toMenuButton.onClick.AddListener(LoadMenuScene);
    }

    private void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
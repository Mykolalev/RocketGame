using UnityEngine;
using UnityEngine.UI;

public class LevelsBootstrap : MonoBehaviour
{
    [SerializeField] private Button[] _levelButtons;
    [SerializeField] private Color _openedLevelColor;
    [SerializeField] private Color _closedLevelColor;

    private string _levelPrefs = PrefsContainer.LevelPrefName;
    private int _unlockedLevels;
     
    public void Init() 
    {
        _unlockedLevels = PlayerPrefs.GetInt(_levelPrefs, 1);
        SetupButtons();
    }
     
    private void SetupButtons()
    {
        for (int i = 0; i < _levelButtons.Length; i++)
        {
            CloseButtonForInteractions(_levelButtons[i]);
        }

        for (int i = 0; i < _unlockedLevels; i++)
        {
            OpenButtonForInteractions(_levelButtons[i]);
        }
    }

    private void OpenButtonForInteractions(Button button)
    {
        button.interactable = true;
        SetGreenColorForOpenedImage(button);
    }

    private void CloseButtonForInteractions(Button button)
    {
        button.interactable = false;
        SetRedColorForOpenedImage(button);
    }

    private void SetGreenColorForOpenedImage(Button button)
    {
        Image buttonImage = button.GetComponent<Image>();
        buttonImage.color = _openedLevelColor;
    }

    private void SetRedColorForOpenedImage(Button button)
    {
        Image buttonImage = button.GetComponent<Image>();
        buttonImage.color = _closedLevelColor;
    }
}
using UnityEngine;
using UnityEngine.UI;

public class ButtonTransitioner : MonoBehaviour
{
    [SerializeField] private CanvasGroup _itsMenu;
    [SerializeField] private CanvasGroup _menuToEnable;
    [SerializeField] private Button _buttonTransitioner; 

    private void Start()
    {
        _buttonTransitioner.onClick.AddListener(MakeTransition);
    }

    private void MakeTransition()
    {
        DisableItsCanvasGroup();
        EnableAnotherCanvasGroup();
    }

    private void EnableAnotherCanvasGroup()
    { 
        _menuToEnable.alpha = 1;
        _menuToEnable.interactable = true;
        _menuToEnable.blocksRaycasts = true;
    }

    private void DisableItsCanvasGroup()
    {
        _itsMenu.alpha = 0;
        _itsMenu.interactable = false;
        _itsMenu.blocksRaycasts = false;
    }
}
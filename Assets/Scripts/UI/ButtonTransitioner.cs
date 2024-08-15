using UnityEngine;
using UnityEngine.UI;

public class ButtonTransitioner : MonoBehaviour
{
    [SerializeField] private GameObject _itsMenu;
    [SerializeField] private GameObject _menuToEnable;
    [SerializeField] private Button _buttonTransitioner;

    private void Start()
    {
        _buttonTransitioner.onClick.AddListener(MakeTransition);
    }

    private void MakeTransition()
    {
        _itsMenu.SetActive(false);
        _menuToEnable.SetActive(true);
    }
}
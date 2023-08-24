using UnityEngine;
using UnityEngine.UI;

public class RocketFuelBar : MonoBehaviour
{
    [SerializeField] private Image _fillingImage;

    public void SetFuel(int fuel)
    {
        _fillingImage.fillAmount = fuel/1000f;
    }
}

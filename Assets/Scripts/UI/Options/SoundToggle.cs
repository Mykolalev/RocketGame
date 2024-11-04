using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI; 

public abstract class SoundToggle : MonoBehaviour
{
    [SerializeField] protected Button Button;
    [SerializeField] protected AudioMixer Mixer;
    [SerializeField] protected Image Image;
    [SerializeField] protected Color GreenColor;
    [SerializeField] protected Color RedColor;

    private bool Enabled = true;

    protected string PrefName;
    protected string PrefBool;

    private void OnEnable() 
    {
        Button.onClick.AddListener(ChangeToggle);
    }
    private void OnDisable()
    { 
        Button.onClick.RemoveListener(ChangeToggle); 
    }

    public void ToggleBootstrap()
    {
        int value = PlayerPrefs.GetInt(PrefBool, 1);
        Enabled = value > 0 ? true : false;
        ChangeMixerSettings();
        ChangeImageColor();
    }

    private void ChangeToggle()
    {
        Enabled = !Enabled;
        SaveEditToBoolPref();
        ChangeMixerSettings();
        ChangeImageColor();
    }

    private void ChangeMixerSettings()
    {
        Mixer.SetFloat(PrefName ,Enabled ? 0 : -80);
    }

    private void ChangeImageColor()
    {
        Image.color = Enabled ? GreenColor : RedColor;
    }

    private void SaveEditToBoolPref()
    {
        PlayerPrefs.SetInt(PrefBool, Enabled ? 1 : 0);
    }
}
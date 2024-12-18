using UnityEngine;

public class MenuBootstrap : MonoBehaviour
{
    [SerializeField] private SoundToggle[] _toggles;
    [SerializeField] private BackgroundMusic _bgMusic;
    [SerializeField] private LevelsBootstrap _levelsBootstrapper; 

    private void Start()
    {
        Bootstrap(); 
    }

    private void Bootstrap()
    {
        foreach (SoundToggle toggle in _toggles)
        {
            toggle.ToggleBootstrap();
        }

        _bgMusic.Bootstrap(); 
        _levelsBootstrapper.Init();
    }
}
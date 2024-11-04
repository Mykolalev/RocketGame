public class MusicToggle : SoundToggle
{
    private void Awake()
    {
        PrefName = PrefsContainer.MusicTogglePrefName;
        PrefBool = PrefsContainer.MusicToggleForBool;
    }
}
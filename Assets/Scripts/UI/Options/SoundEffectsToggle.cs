public class SoundEffectsToggle : SoundToggle
{
    private void Awake()
    {
        PrefName = PrefsContainer.SoundEffectsTogglePrefName;
        PrefBool = PrefsContainer.SoundEffectsToggleForBool;
    }
}
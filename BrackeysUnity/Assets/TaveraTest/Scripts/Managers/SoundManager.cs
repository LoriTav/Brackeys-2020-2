using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BackgroundTheme { menu, game};

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public bool enableSoundEfx = true;
    public bool enableBackgroundTheme = true;

    [Range(0,1)]
    public float volume;

    [Range(0, 1)]
    public float soundFXVolume;

    public AudioClip BGgameAudioClip;
    public AudioClip BGMainMenuAudioClip;

    private AudioSource backgroundAS;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        backgroundAS = GetComponent<AudioSource>();
        backgroundAS.loop = true;
        backgroundAS.volume = volume;

        PlayBGTheme(BackgroundTheme.game);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBGTheme(BackgroundTheme BGTheme)
    {
        if (!enableBackgroundTheme) { return; }

        backgroundAS.Stop();
        backgroundAS.clip = BGTheme == BackgroundTheme.game ? BGgameAudioClip : BGMainMenuAudioClip;
        backgroundAS.Play();
    }

    public void enableBackgroundMusic()
    {
        backgroundAS.volume = volume;
        enableBackgroundTheme = true;
    }
    public void disableBackgroundMusic()
    {
        backgroundAS.volume = 0;
        enableBackgroundTheme = false;
    }
    public void enableSoundEfxVolume()
    {
        enableSoundEfx = true;
    }
    public void disableSoundEfxVolume()
    {
        enableSoundEfx = false;
    }
}

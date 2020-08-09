using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    // Update is called once per frame
    void Update()
    {
        PlayBGTheme();
    }

    public void PlayBGTheme()
    {
        if (!enableBackgroundTheme) { return; }

        AudioClip clipToPlay;

        switch(SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                clipToPlay = BGgameAudioClip;
                break;
            case 0: case 2:
                clipToPlay = BGMainMenuAudioClip;
                break;
            default:
                clipToPlay = BGgameAudioClip;
                break;
        }

        if(clipToPlay == backgroundAS.clip) { return; }

        backgroundAS.Stop();
        backgroundAS.clip = clipToPlay;
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

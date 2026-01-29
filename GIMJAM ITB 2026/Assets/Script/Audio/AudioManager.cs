using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }


    public AudioSource audioSource;
    public AudioSource SFXSource;

    public AudioClip backgroundMainMenu;
    public AudioClip backgroundInGame;
    public AudioClip click;
    public AudioClip shoot;


    private void Start()
    {
        audioSource.clip = backgroundMainMenu;
        audioSource.Play();
    }
    public void PlayBackground(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void MuteSound()
    {
        SFXSource.mute = !SFXSource.mute;
    }
    public void MuteMusic()
    {
        audioSource.mute = !audioSource.mute;
    }
    public bool IsSoundMuted()
    {
        return SFXSource.mute;
    }


    public bool IsMusicMuted()
    {
        return audioSource.mute;
    }
}

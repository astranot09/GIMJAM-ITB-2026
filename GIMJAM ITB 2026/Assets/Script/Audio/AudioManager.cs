using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    public AudioSource audioSource;
    public AudioSource SFXSource;

    public AudioClip background;
    public AudioClip click;



    private void Start()
    {
        audioSource.clip = background;
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

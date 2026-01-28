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
        DontDestroyOnLoad(gameObject);
    }


    public AudioSource audioSource;

    public AudioClip background;
    public AudioClip click;

    private void Start()
    {
        audioSource.clip = background;
        audioSource.Play();
    }
}

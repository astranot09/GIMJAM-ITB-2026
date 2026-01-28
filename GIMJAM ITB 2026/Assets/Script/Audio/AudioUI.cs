using UnityEngine;
using UnityEngine.UI;
public class AudioUI : MonoBehaviour
{
    [Header("Music")]
    public Image musicButtonImage;
    public Sprite muteMusic;
    public Sprite unmuteMusic;


    [Header("Sound")]
    public Image soundButtonImage;
    public Sprite muteSound;
    public Sprite unmuteSound;


    private void Start()
    {
        UpdateUI();
    }


    public void ToggleMusic()
    {
        AudioManager.instance.MuteMusic();
        UpdateUI();
        AudioManager.instance.PlaySFX(AudioManager.instance.click);
    }


    public void ToggleSound()
    {
        AudioManager.instance.MuteSound();
        UpdateUI();
        AudioManager.instance.PlaySFX(AudioManager.instance.click);
    }


    void UpdateUI()
    {
        // Music icon
        musicButtonImage.sprite =
        AudioManager.instance.IsMusicMuted() ? muteMusic : unmuteMusic;


        // Sound icon
        soundButtonImage.sprite =
        AudioManager.instance.IsSoundMuted() ? muteSound : unmuteSound;
    }
}
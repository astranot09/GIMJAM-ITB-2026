using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private TMP_Text notifText;

    private Tween notifTween;

    private void Start()
    {
        notifText.alpha = 0f;
    }

    public void Notification(string text)
    {
        notifText.text = text;

        // Stop animasi sebelumnya (kalau notif dipanggil cepat)
        notifTween?.Kill();

        notifTween = DOTween.Sequence()
        .Append(notifText.DOFade(1f, 0.4f)) // Fade In
        .AppendInterval(1.2f) // Diam sebentar
        .Append(notifText.DOFade(0f, 0.4f)); // Fade Out
    }
}

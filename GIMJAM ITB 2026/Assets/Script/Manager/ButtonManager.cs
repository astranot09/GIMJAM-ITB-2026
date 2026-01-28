using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject creditPanel;
    [SerializeField] private GameObject losePanel;

    public void Paused()
    {
        if (losePanel.activeSelf)
            return;

        pausePanel.SetActive(!pausePanel.activeSelf);
        if(pausePanel.activeSelf)
            Time.timeScale = 0f;
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Lose()
    {
        losePanel.SetActive(true);
        LeaderboardManager.instance.AddScore(GameManager.instance.score);
        Time.timeScale = 0f;
    }

    public void Exit()
    {
        SceneController.instance.Homepage();
    }
    public void Credit()
    {
        creditPanel.SetActive(!creditPanel.activeSelf);
    }

}

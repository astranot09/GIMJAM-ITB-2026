using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}

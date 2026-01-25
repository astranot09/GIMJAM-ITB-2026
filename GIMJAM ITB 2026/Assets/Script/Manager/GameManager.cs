using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }
    public int score = 0;
    public int wave = 0;


    public bool onMinigame = false;

    public void GameTime()
    {
        onMinigame = true;
        ClickingManager.instance.ClickGameTime();
    }
}

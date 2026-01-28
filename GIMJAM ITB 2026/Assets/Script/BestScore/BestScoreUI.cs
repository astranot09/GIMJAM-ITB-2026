using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BestScoreUI : MonoBehaviour
{

    //LeaderboardManager leaderboardManager;
    [SerializeField] private TMP_Text bestScoreText;
    void Start()
    {
        //leaderboardManager = GameObject.Find("LeaderBoardManager")?.GetComponent<LeaderboardManager>();
        bestScoreText.text = (LeaderboardManager.instance.GetBestScore()).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

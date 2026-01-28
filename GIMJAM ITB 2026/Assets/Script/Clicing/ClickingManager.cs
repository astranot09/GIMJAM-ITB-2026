using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ClickingManager : MonoBehaviour
{

    public static ClickingManager instance;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private float currTime;
    [SerializeField] private float maxTime;
    [SerializeField] private TMP_Text timerText;
    public float clickCount = 0;

    public bool clickingTime = false;

    [SerializeField] private Player player;

    void Start()
    {
        timerText.gameObject.SetActive(false);
        currTime = maxTime;
    }
    void Update()
    {
        if(currTime >= 0 && clickingTime)
        {
            timerText.gameObject.SetActive(true);
            currTime -= Time.deltaTime;
            timerText.text = currTime.ToString("F0");
        }
        else if(currTime < 0 && clickingTime)
        {
            timerText.gameObject.SetActive(false);
            clickingTime = false;
            EnemySpawner.instance.AttackTime();
            player.CalculateAmmo(clickCount);
        }
    }

    public void ClickGameTime()
    {
        clickingTime = true;
        currTime = maxTime;
    }

}

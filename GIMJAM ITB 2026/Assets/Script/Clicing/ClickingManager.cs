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
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private float currTime;
    [SerializeField] private float maxTime;
    [SerializeField] private TMP_Text timerText;
    public float clickCount = 0;

    public bool clickingTime = false;

    void Start()
    {
        currTime = maxTime;
    }
    void Update()
    {
        if(currTime >= 0 && clickingTime)
        {
            currTime -= Time.deltaTime;
            timerText.text = currTime.ToString("F2");
        }
        else
        {
            clickingTime = false;
        }
    }
}

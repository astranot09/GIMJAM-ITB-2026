using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pohon : MonoBehaviour
{
    private bool trigger = false;
    [SerializeField] private float speed;
    public PohonSpawner spawner;

    private void Start()
    {
        EnemySpawner.instance.spawnCurr = 0;
        ClickingManager.instance.clickCount = 0;
        WaveManager.instance.wave++;
        WaveManager.instance.CheckWave();
    }
    void Update()
    {
        if (!GameManager.instance.onMinigame)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GameController"))
        {
            if (!trigger)
            {
                trigger = true;
                GameManager.instance.GameTime();
                //AwanSpawner.instance.SpawnRandomTarget(WaveManager.instance.wave / 10);
            }
                
        }
        if (collision.CompareTag("Notif"))
        {
            NotificationManager.instance.Notification("You have 10 seconds to make bullet");
        }
        if (collision.CompareTag("Delete"))
        {
            Debug.Log("hi");
            spawner.SpawnPohon();
            Destroy(gameObject);
        }

    }
}

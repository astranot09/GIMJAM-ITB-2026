using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pohon : MonoBehaviour
{
    private bool trigger = false;
    [SerializeField] private float speed;
    public PohonSpawner spawner;


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
            }
                
        }
        if (collision.CompareTag("Delete"))
        {
            Debug.Log("hi");
            spawner.SpawnPohon();
            Destroy(gameObject);
        }

    }
}

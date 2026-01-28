using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimScript : MonoBehaviour
{
    private bool trigger = false;
    [SerializeField] private float speed;
    public PohonSpawner spawner;
    [SerializeField] Animator animator;
    [SerializeField] private SpriteRenderer sr;

    private Rigidbody2D rb;
    private void Start()
    {
        animator = GetComponent<Animator>();
        EnemySpawner.instance.spawnCurr = 0;
        ClickingManager.instance.clickCount = 0;
        WaveManager.instance.wave++;
        WaveManager.instance.CheckWave();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!GameManager.instance.onMinigame)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GameController"))
        {
            if (!trigger)
            {
                trigger = true;
                JumpAnimation();
                GameManager.instance.GameTime();
                //AwanSpawner.instance.SpawnRandomTarget(WaveManager.instance.wave / 10);
            }

        }
        if (collision.CompareTag("Notif"))
        {
            NotificationManager.instance.Notification("You have 7 seconds to make bullet");
        }
        if (collision.CompareTag("Delete"))
        {
            Debug.Log("hi");
            spawner.SpawnPohon();
            Destroy(gameObject);
        }

    }

    public void RunAnimation()
    {
        //animator.SetBool("isRunning", true);
        Debug.Log("Jump");
    }

    public void JumpAnimation()
    {
        animator.SetTrigger("isJumping");
        Debug.Log("Jump");
        //rb.velocity = new Vector2(rb.velocity.x, 2);
        //animator.SetTrigger("isJumping");

    }
    public void FallAnimation()
    {
        animator.SetTrigger("isFalling");
        Debug.Log("Fall");
    }

    public void Hide()
    {
        Debug.Log("Hilang");
        sr.enabled = false;
    }
    public void UnHide()
    {
        sr.enabled = true;
    }
}

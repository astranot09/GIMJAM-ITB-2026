using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimScript : MonoBehaviour
{
    private bool trigger = false;
    [SerializeField] private float speed;
    public PohonSpawner spawner;
    //[SerializeField] Animator animator;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject border;
    private Rigidbody2D rb;
    private void Start()
    {
        //animator = GetComponent<Animator>();
        EnemySpawner.instance.spawnCurr = 0;
        ClickingManager.instance.clickCount = 0;
        WaveManager.instance.wave++;
        WaveManager.instance.CheckWave();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        border = GameObject.Find("Floor2");
    }
    void Update()
    {
        //if (!GameManager.instance.onMinigame)
        //{
            transform.position += Vector3.right * speed * Time.deltaTime;
        //}
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
                StartCoroutine(UnHide());
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
            border.SetActive(true);
            Destroy(gameObject);
        }

    }

    public void RunAnimation()
    {
        //animator.SetBool("isRunning", true);
        //Debug.Log("Jump");
    }

    public void JumpAnimation()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        border.SetActive(true);
    }
    public void FallAnimation()
    {
        //animator.SetTrigger("isFalling");
        Debug.Log("Fall");
        border.SetActive(false);
        StartCoroutine(Hide());
    }

    private IEnumerator UnHide()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("pppp");
        RedTopTreeScript red = GameObject.Find("RedTopTree").GetComponent<RedTopTreeScript>();
        red.UnHide();
    }
    private IEnumerator Hide()
    {
        yield return new WaitForSeconds(0.1f);
        RedTopTreeScript red = GameObject.Find("RedTopTree").GetComponent<RedTopTreeScript>();
        red.Hide();
    }
}

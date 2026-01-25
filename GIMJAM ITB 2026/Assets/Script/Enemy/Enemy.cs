using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Health")]
    [SerializeField] private float currHealth;
    [SerializeField] private float maxHealth = 1f;

    [Header("Find Player")]
    [SerializeField] private Player player;
    [SerializeField] private Transform playerLocation;
    [SerializeField] private Rigidbody2D rb;
    public float moveSpeed = 3f;
    private void Start()
    {
        playerLocation = GameObject.FindGameObjectWithTag("PlayerBush").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        currHealth = maxHealth;
        StartCoroutine(Delay());
    }

    private void FixedUpdate()
    {
        Vector2 direction = (playerLocation.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBush"))
        {
            player.GetAttacked(1);
            EnemySpawner.instance.EnemyDead();
            Destroy(gameObject);
        }
    }

    public void GetAttacked(float damage)
    {
        currHealth -= damage;
        if(currHealth <= 0)
        {
            Destroy(gameObject);
            EnemySpawner.instance.EnemyDead();
        }
        GameManager.instance.score++;
    }

    IEnumerator Delay()
    {
        var i = moveSpeed;
        moveSpeed = 0;
        yield return new WaitForSeconds(2f);
        moveSpeed = i;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState
{
    RunToTree, // nunggu pohon datang
    ClickingTree, // clicker
    ShootGhost, // tembak
    Falling // jatuh
}
public class PlayerController : MonoBehaviour
{
    public PlayerState state;

    [Header("Clicker")]
    public float clickDuration = 5f;
    private float clickTimer;


    [Header("Shoot")]
    public float shootDuration = 3f;
    private float shootTimer;


    private Animator anim;
    private Rigidbody2D rb;


    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        ChangeState(PlayerState.RunToTree);
    }


    void Update()
    {
        anim.SetInteger("state", (int)state);


        if (state == PlayerState.ClickingTree)
            clickTimer -= Time.deltaTime;


        if (state == PlayerState.ShootGhost)
            shootTimer -= Time.deltaTime;


        if (state == PlayerState.ClickingTree && clickTimer <= 0)
            ChangeState(PlayerState.ShootGhost);


        if (state == PlayerState.ShootGhost && shootTimer <= 0)
            ChangeState(PlayerState.Falling);
    }


    void ChangeState(PlayerState newState)
    {
        state = newState;


        switch (state)
        {
            case PlayerState.RunToTree:
                rb.gravityScale = 0;
                break;


            case PlayerState.ClickingTree:
                clickTimer = clickDuration;
                break;


            case PlayerState.ShootGhost:
                shootTimer = shootDuration;
                break;


            case PlayerState.Falling:
                rb.gravityScale = 3f;
                break;
        }
    }


    // dipanggil dari pohon
    public void StartClicker()
    {
        if (state == PlayerState.RunToTree)
            ChangeState(PlayerState.ClickingTree);
    }


    public void OnTreeClicked()
    {
        if (state != PlayerState.ClickingTree) return;
        Debug.Log("Tree clicked!");
    }


    public void OnShoot()
    {
        if (state != PlayerState.ShootGhost) return;
        Debug.Log("Shoot ghost!");
    }
}

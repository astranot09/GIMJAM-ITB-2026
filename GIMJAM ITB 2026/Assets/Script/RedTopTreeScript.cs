using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTopTreeScript : MonoBehaviour
{

    public static RedTopTreeScript instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private SpriteRenderer sr;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        Hide();
    }
    public void TakeSkull()
    {
        animator.SetTrigger("Take");
    }

    public void Hide()
    {
        sr.enabled = false;
    }
    public void UnHide()
    {
        sr.enabled = true;
    }

}

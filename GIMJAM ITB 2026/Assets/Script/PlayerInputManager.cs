using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DissableMode();
    }
    public void ClickingMode()
    {
        var playerInput = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("Clicking");
    }
    public void AttackMode()
    {
        var playerInput = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("Attack");
    }
    public void DissableMode()
    {
        var playerInput = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerInput>();
        if (playerInput == null)
            Debug.Log("gagal");
        playerInput.DeactivateInput();
    }
}

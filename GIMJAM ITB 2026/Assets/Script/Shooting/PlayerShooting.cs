using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerShooting : MonoBehaviour
{
    //private Camera mainCam;
    //private Vector3 mousePos;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private bool canFire;
    [SerializeField] private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
        //mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    private void Update()
    {
        //mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 rotation = mousePos - transform.position;
        //float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0,0,rotZ);
    }

    public void OnAttack(CallbackContext ctx)
    {
        if (ButtonManager.instance.paused) return;
        if (ctx.performed && player.ammo > 0)
        {
            canFire = false;
            Instantiate(bullet,bulletTransform.position,Quaternion.identity);
            player.ammo--;
            PlayerUI.instance.UpdateAmmoUI();
        }
        if(ctx.canceled)
            canFire = true;
    }

}

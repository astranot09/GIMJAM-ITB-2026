using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public float currHealth;
    public float maxHealth = 3;
    
    public int ammo = 0;

    private void Start()
    {
        currHealth = maxHealth;
        PlayerUI.instance.UpdateHealthUI();
        PlayerUI.instance.UpdateAmmoUI();
    }

    public void GetAttacked(float damage)
    {
        currHealth -= damage;
        PlayerUI.instance.UpdateHealthUI();
        if (currHealth <= 0)
        {
            ButtonManager.instance.Lose();
            Destroy(gameObject);
        }
        //GameManager.instance.score++;
    }

    public void CalculateAmmo(float skull)
    {
        ammo += Mathf.RoundToInt(skull * 2 / 3);
        PlayerUI.instance.UpdateAmmoUI();
    }
}

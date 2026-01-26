using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private Player player;
    [SerializeField] private GameObject healthImagePreFab;
    [SerializeField] private Transform healthBar;

    [SerializeField] private TMP_Text ammoCount;
    [SerializeField] private TMP_Text scoreCount;
    public void UpdateHealthUI()
    {
        foreach (Transform child in healthBar)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < player.currHealth; i++)
        {
            Instantiate(healthImagePreFab, healthBar);
        }
    }
    public void UpdateAmmoUI()
    {
        ammoCount.text = player.ammo.ToString();
    }
    public void UpdateScoreUI()
    {
        scoreCount.text = GameManager.instance.score.ToString();
    }
}

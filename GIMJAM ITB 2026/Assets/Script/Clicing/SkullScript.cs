using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkullScript : MonoBehaviour
{
    public SkullSpawner skullSpawner;
    private void OnMouseDown()
    {
        if (ButtonManager.instance.paused) return;
        if (!ClickingManager.instance.clickingTime) return;
        Debug.Log("Click");
        skullSpawner.spawnCurr--;
        Clicking();
        skullSpawner.SpawnSkull();
        ClickingManager.instance.clickCount++;
        AudioManager.instance.PlaySFX(AudioManager.instance.click);
        Destroy(gameObject);
    }

    private void Clicking()
    {
        RedTopTreeScript red = GameObject.Find("RedTopTree").GetComponent<RedTopTreeScript>();
        red.TakeSkull();
    }
}

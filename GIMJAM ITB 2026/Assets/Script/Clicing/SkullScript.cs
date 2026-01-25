using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkullScript : MonoBehaviour
{
    public SkullSpawner skullSpawner;
    private void OnMouseDown()
    {
        if(!ClickingManager.instance.clickingTime) return;
        Debug.Log("Click");
        skullSpawner.spawnCurr--;
        skullSpawner.SpawnSkull();
        ClickingManager.instance.clickCount++;
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public int wave = 0;

    public void CheckWave()
    {
        if (wave % 3 == 1 && wave != 1)
        {
            EnemySpawner.instance.spawnMax++;
        }
        if (wave % 5 == 1 && wave != 1)
        {
            EnemySpawner.instance.enemySpeed += 0.1f;
        }
        if (wave % 10 == 1 && wave != 1)
        {
            AwanSpawner.instance.SpawnRandomTarget();
        }
    }
}

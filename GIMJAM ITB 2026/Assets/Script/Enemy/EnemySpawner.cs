using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }
    [SerializeField] private GameObject enemyPrefab;
    public float enemySpeed;

    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    public int spawnMax = 5;
    public int spawnCurr = 0;

    public int enemyDead = 0;

    private void Start()
    {
        //AttackTime();
    }
    private void SpawnEnemy()
    {
        if (spawnCurr >= spawnMax) return;

        List<Transform> emptyPivots = new List<Transform>();
        foreach (Transform pivot in spawnPoints)
        {
            if (pivot.childCount == 0)
                emptyPivots.Add(pivot);
        }


        if (emptyPivots.Count == 0) return;


        Transform chosenPivot = emptyPivots[Random.Range(0, emptyPivots.Count)];

        GameObject enemy = Instantiate(enemyPrefab, chosenPivot.position, Quaternion.identity, chosenPivot);
        enemy.GetComponent<Enemy>().moveSpeed = enemySpeed;

        spawnCurr++;


    }

    public void EnemyDead()
    {
        enemyDead++;
        if (enemyDead == spawnMax)
        {
            Debug.Log("selesai");
            enemyDead = 0;
            GameManager.instance.onMinigame = false;
            PlayerInputManager.instance.DissableMode();

            AwanSpawner.instance.DeleteAwan();
        }
    }
    public void AttackTime()
    {
        NotificationManager.instance.Notification("Kill the Enemy!!");
        StartCoroutine(Delay());
        
    }


    IEnumerator SpawningEnemyWave()
    {
        for(int i = 0; i < spawnMax; i++)
        {
            yield return new WaitForSeconds(0.6f);
            SpawnEnemy();
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        PlayerInputManager.instance.AttackMode();
        StartCoroutine(SpawningEnemyWave());
    }
}

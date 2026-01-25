using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullSpawner : MonoBehaviour
{
    [SerializeField] private GameObject skullPrefab;


    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    public int spawnMax = 5;
    public int spawnCurr = 0;

    void Start()
    {
        while(spawnCurr < spawnMax)
        {
            SpawnSkull();
        }
        
    }

    public void SpawnSkull()
    {
        if (spawnCurr >= spawnMax) return;

            // cari pivot kosong
            List<Transform> emptyPivots = new List<Transform>();
            foreach (Transform pivot in spawnPoints)
            {
                if (pivot.childCount == 0)
                    emptyPivots.Add(pivot);
            }


            if (emptyPivots.Count == 0) return;


            Transform chosenPivot = emptyPivots[Random.Range(0, emptyPivots.Count)];


            GameObject skull = Instantiate(skullPrefab, chosenPivot.position, Quaternion.identity, chosenPivot);
            skull.GetComponent<SkullScript>().skullSpawner = this;

            spawnCurr++;


    }
}

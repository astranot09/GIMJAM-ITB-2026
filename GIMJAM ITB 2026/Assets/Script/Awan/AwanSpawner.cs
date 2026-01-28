using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwanSpawner : MonoBehaviour
{
    public static AwanSpawner instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }


    public Vector2 minArea = new Vector2(-8, -4);
    public Vector2 maxArea = new Vector2(8, 4);


    private Vector2 locationSpawn;
    [SerializeField] private GameObject awanPrefab;

    //public void SpawnRandomTarget(int n)
    //{
    //    for(int i = 0; i < n; i++)
    //    {
    //        locationSpawn = new Vector2(
    //        Random.Range(minArea.x, maxArea.x),
    //        Random.Range(minArea.y, maxArea.y)
    //        );
    //        Instantiate(awanPrefab, locationSpawn, Quaternion.identity);
    //    }

    //}
    //public void DeleteAwan()
    //{
    //    GameObject[] awan = GameObject.FindGameObjectsWithTag("Awan");


    //    foreach (GameObject a in awan)
    //    {
    //        Destroy(a);
    //    }
    //}
    public void SpawnRandomTarget()
    {
        locationSpawn = new Vector2(
        Random.Range(minArea.x, maxArea.x),
        Random.Range(minArea.y, maxArea.y)
        );
        Instantiate(awanPrefab, locationSpawn, Quaternion.identity);

    }
}

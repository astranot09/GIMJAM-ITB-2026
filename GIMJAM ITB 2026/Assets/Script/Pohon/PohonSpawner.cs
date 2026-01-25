using UnityEngine;

public class PohonSpawner : MonoBehaviour
{
    [SerializeField] private float currTime;
    [SerializeField] private float maxTime;
    [SerializeField] private GameObject pohon;
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        SpawnPohon();
    }
    public void SpawnPohon()
    {
        GameObject pohon = Instantiate(this.pohon, spawnPoint);
        pohon.GetComponent<Pohon>().spawner = this;
    }
}

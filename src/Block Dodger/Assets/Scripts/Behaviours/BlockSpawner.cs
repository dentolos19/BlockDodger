using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public float spawnTime = 2;
    public float spawnTimeBetweenWaves = 1;
    public GameObject obstaclePrefab;
    public Transform[] spawnPoints;

    private void Update()
    {
        if (Time.time >= spawnTime)
        {
            SpawnBlocks();
            spawnTime = Time.time + spawnTimeBetweenWaves;
        }
    }

    private void SpawnBlocks()
    {
        var safeIndex = Random.Range(0, spawnPoints.Length);
        for (var index = 0; index < spawnPoints.Length; index++)
        {
            if (safeIndex == index)
                continue;
            Instantiate(obstaclePrefab, spawnPoints[index].position, Quaternion.identity);
        }
    }

}
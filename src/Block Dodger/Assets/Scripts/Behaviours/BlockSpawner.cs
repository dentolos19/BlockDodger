using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public float spawnTime = 2;
    public float spawnTimeBetweenWaves = 1;
    public GameObject goalPrefab;
    public GameObject obstaclePrefab;
    public Transform[] spawnPoints;

    private void Update()
    {
        if (!(Time.time >= spawnTime))
            return;
        SpawnBlocks();
        spawnTime = Time.time + spawnTimeBetweenWaves;
    }

    private void SpawnBlocks()
    {
        var safeIndex = Random.Range(0, spawnPoints.Length);
        for (var index = 0; index < spawnPoints.Length; index++)
            if (safeIndex != index)
                Instantiate(obstaclePrefab, spawnPoints[index].position, Quaternion.identity);
        Instantiate(goalPrefab, spawnPoints[safeIndex].position, Quaternion.identity);
    }

}
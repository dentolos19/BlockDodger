using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
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
        var goalIndex = Random.Range(0, spawnPoints.Length);
        for (var index = 0; index < spawnPoints.Length; index++)
            if (index != goalIndex)
                Instantiate(obstaclePrefab, spawnPoints[index].position, quaternion.identity);
        Instantiate(goalPrefab, spawnPoints[goalIndex].position, quaternion.identity);
        spawnTime = Time.time + spawnTimeBetweenWaves;
    }
}
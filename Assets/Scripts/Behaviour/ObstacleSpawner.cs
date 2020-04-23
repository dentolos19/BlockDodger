using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    private float _spawnTime = 2f;
    private readonly System.Random _randomizer = new System.Random();

    public GameObject prefab;
    public Transform[] points;

    private void Update()
    {
        if (!(Time.time >= _spawnTime))
            return;
        Spawn();
        _spawnTime = Time.time + 1f;
    }

    private void Spawn()
    {
        var random = _randomizer.Next(points.Length);
        for (var index = 0; index < points.Length; index++)
            if (random != index)
                Instantiate(prefab, points[index].position, Quaternion.identity);
    }

}
using TMPro;
using UnityEngine;
using Random = System.Random;

public class ObstacleSpawner : MonoBehaviour
{

    private readonly Random _randomizer = new Random();

    private int _score;
    private float _spawnTime = 2f;
    public TextMeshProUGUI counter;
    public Transform[] points;

    public GameObject prefab;

    private void Start()
    {
        _score = -1;
        Game.EndPassArgs = _score;
    }

    private void Update()
    {
        counter.text = _score.ToString();
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
        _score++;
        Game.EndPassArgs = _score;
    }

}
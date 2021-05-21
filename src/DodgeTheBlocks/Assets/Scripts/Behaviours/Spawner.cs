using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{

    private float mTime;
    private readonly Random mRandomizer = new Random();
    
    public GameObject goalPrefab;
    public GameObject obstaclePrefab;
    public Transform[] points;

    private void Update()
    {
        if (!(Time.time >= mTime))
            return;
        Spawn();
        mTime = Time.time + 1;
    }
    
    private void Spawn()
    {
        var random = mRandomizer.Next(points.Length);
        for (var index = 0; index < points.Length; index++)
            Instantiate(random != index ? obstaclePrefab : goalPrefab, points[index].position, Quaternion.identity);
    }

}
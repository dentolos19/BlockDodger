using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{

<<<<<<< HEAD
    private float mTime;
    private readonly Random mRandomizer = new Random();
=======
    private float _time;
    private readonly Random _randomizer = new Random();
>>>>>>> DodgeTheBlocksOld/master
    
    public GameObject goalPrefab;
    public GameObject obstaclePrefab;
    public Transform[] points;

    private void Update()
    {
<<<<<<< HEAD
        if (!(Time.time >= mTime))
            return;
        Spawn();
        mTime = Time.time + 1;
=======
        if (!(Time.time >= _time))
            return;
        Spawn();
        _time = Time.time + 1;
>>>>>>> DodgeTheBlocksOld/master
    }
    
    private void Spawn()
    {
<<<<<<< HEAD
        var random = mRandomizer.Next(points.Length);
=======
        var random = _randomizer.Next(points.Length);
>>>>>>> DodgeTheBlocksOld/master
        for (var index = 0; index < points.Length; index++)
            Instantiate(random != index ? obstaclePrefab : goalPrefab, points[index].position, Quaternion.identity);
    }

}
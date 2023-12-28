using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -6)
            Destroy(gameObject);
    }
}
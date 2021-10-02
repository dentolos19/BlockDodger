using UnityEngine;

public class BlockDestroyer : MonoBehaviour
{

    private void Update()
    {
        if (transform.position.y < -6)
            Destroy(gameObject);
    }

}
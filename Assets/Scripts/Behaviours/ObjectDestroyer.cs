using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{

    private void Update()
    {
        if (transform.position.y < -5)
            Destroy(gameObject);
    }

}
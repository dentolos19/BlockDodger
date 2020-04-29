using UnityEngine;

public class Destroyer : MonoBehaviour
{

    private void Update()
    {
        if (transform.position.y <= -6)
            Destroy(gameObject);
    }

}
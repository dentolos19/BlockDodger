using UnityEngine;

public class Destroyer : MonoBehaviour
{

    private void Update()
    {
        if (transform.position.y <= -5)
            Destroy(transform.gameObject);
    }

}
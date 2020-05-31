using UnityEngine;

public class Destroyer : MonoBehaviour
{

    private void Update()
    {
<<<<<<< HEAD
        if (transform.position.y <= -6)
=======
        if (transform.position.y <= -5)
>>>>>>> DodgeTheBlocksOld/master
            Destroy(transform.gameObject);
    }

}
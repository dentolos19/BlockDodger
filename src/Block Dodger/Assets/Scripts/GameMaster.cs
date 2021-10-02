using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    public void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
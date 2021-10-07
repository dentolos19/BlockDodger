using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{

    public void OnBack()
    {
        Game.RestoreTime();
        SceneManager.LoadScene(0);
    }

    public void OnRetry()
    {
        Game.RestoreTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

}
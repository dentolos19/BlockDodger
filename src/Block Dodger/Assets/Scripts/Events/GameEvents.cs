using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{

    public GameObject deathMenu;

    public void OnBack()
    {
        Game.ResetTime();
        SceneManager.LoadScene(0);
    }

    public void OnRetry()
    {
        Game.ResetTime();
        SceneManager.LoadScene(1);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

}
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{

    public void OnBack()
    {
        Game.RestoreTimeSettings();
        SceneManager.LoadScene(0);
    }

    public void OnRetry()
    {
        Game.RestoreTimeSettings();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

}
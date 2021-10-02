using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnShowMain()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void OnShowOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

}
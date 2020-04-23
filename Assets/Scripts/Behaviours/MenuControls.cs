using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{

    public Slider optionsSensitivity;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SaveOptions()
    {
        var settings = Configuration.Load();
        settings.Sensitivity = optionsSensitivity.value * 100;
        settings.Save();
    }

    public void LoadOptions()
    {
        var settings = Configuration.Load();
        optionsSensitivity.value = settings.Sensitivity / 100;
    }


}
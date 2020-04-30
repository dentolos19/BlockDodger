using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public Slider optionsSensitivity;
    public Toggle optionsUseTouchControls;

    private void Start()
    {
        optionsSensitivity.value = Game.Settings.Sensitivity;
        optionsUseTouchControls.isOn = Game.Settings.UseTouchControls;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Save()
    {
        Game.Settings.Sensitivity = optionsSensitivity.value;
        Game.Settings.UseTouchControls = optionsUseTouchControls.isOn;
        Game.Settings.Save();
    }

    public void Exit()
    {
        Application.Quit();
    }

}
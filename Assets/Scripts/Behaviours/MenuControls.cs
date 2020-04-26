using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{

    public Slider optionsSensitivity;
    public Toggle optionsMuteGameSounds;
    public Toggle optionsUseTouchControls;

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
        Game.Settings.Sensitivity = optionsSensitivity.value * 100;
        Game.Settings.MuteGameSounds = optionsMuteGameSounds.isOn;
        Game.Settings.UseTouchControls = optionsUseTouchControls.isOn;
        Game.Settings.Save();
        var component = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicSound>();
        if (Game.Settings.MuteGameSounds)
            component.Stop();
        else
            component.Play();
    }

    public void LoadOptions()
    {
        optionsSensitivity.value = Game.Settings.Sensitivity / 100;
        optionsMuteGameSounds.isOn = Game.Settings.MuteGameSounds;
        optionsUseTouchControls.isOn = Game.Settings.UseTouchControls;
    }

}
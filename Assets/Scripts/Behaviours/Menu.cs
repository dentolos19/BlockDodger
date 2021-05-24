using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject agreementMenu;

    public Slider optionsSensitivity;
    public Toggle optionsMuteSounds;
    public Dropdown optionsControlType;

    private void Start()
    {
        optionsSensitivity.value = Game.Settings.Sensitivity;
        optionsControlType.value = Game.Settings.ControlType;
        optionsMuteSounds.isOn = Game.Settings.MuteSounds;
        if (!Game.Settings.MuteSounds)
            Music.Instance.Play();
    }

    public void Save()
    {
        Game.Settings.Sensitivity = optionsSensitivity.value;
        Game.Settings.ControlType = optionsControlType.value;
        Game.Settings.MuteSounds = optionsMuteSounds.isOn;
        Game.Settings.Save();
        if (Game.Settings.MuteSounds)
            Music.Instance.Stop();
        else
            Music.Instance.Play();
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        agreementMenu.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        agreementMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject introMenu;
    public Slider optionsSensitivity;
    public Toggle optionsUseTouchControls;
    
    private void Start()
    {
        optionsSensitivity.value = Game.Settings.Sensitivity;
        optionsUseTouchControls.isOn = Game.Settings.UseTouchControls;
        if (Game.Settings.PrivacyPolicyAgreed)
            return;
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        introMenu.SetActive(true);
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

    public void LearnMore()
    {
        Application.OpenURL("https://unity3d.com/legal/privacy-policy");
    }

    public void Agree()
    {
        Game.Settings.PrivacyPolicyAgreed = true;
        Game.Settings.Save();
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        introMenu.SetActive(false);
    }
    
}
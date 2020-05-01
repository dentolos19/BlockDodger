using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject agreementMenu;

    public GameObject mainMenu;

    public TMP_Dropdown optionsControls;
    public GameObject optionsMenu;
    public Slider optionsSensitivity;

    private void Start()
    {
        optionsSensitivity.value = Game.Settings.Sensitivity;
        optionsControls.value = (int)Game.Settings.Control;
        if (Game.Settings.PrivacyPolicyAgreed)
            return;
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        agreementMenu.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Save()
    {
        Game.Settings.Sensitivity = optionsSensitivity.value;
        Game.Settings.Control = (Configuration.GameControl)optionsControls.value;
        Game.Settings.Save();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Agree()
    {
        Game.Settings.PrivacyPolicyAgreed = true;
        Game.Settings.Save();
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        agreementMenu.SetActive(false);
    }

    public void Redirect()
    {
        Application.OpenURL("https://dentolos19.github.io/DodgeTheBlocks/privacy");
    }

}
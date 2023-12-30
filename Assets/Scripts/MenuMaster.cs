using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuMaster : MonoBehaviour
{
    private UIDocument _ui;
    private VisualElement _mainMenu;
    private VisualElement _settingsMenu;

    private void Start()
    {
        _ui = FindFirstObjectByType<UIDocument>();
        _mainMenu = _ui.rootVisualElement.Q<VisualElement>("MainMenu");
        _settingsMenu = _ui.rootVisualElement.Q<VisualElement>("SettingsMenu");
        InitializeMainMenu(_mainMenu);
        InitializeSettingsMenu(_settingsMenu);
    }

    private void InitializeMainMenu(VisualElement root)
    {
        var startButton = root.Q<Button>("StartButton");
        var settingsButton = root.Q<Button>("SettingsButton");
        var quitButton = root.Q<Button>("QuitButton");
        startButton.clicked += () => SceneManager.LoadScene(1);
        settingsButton.clicked += () =>
        {
            _settingsMenu.Q<Slider>("SensitivitySlider").value = GameStore.Sensitivity;
            _mainMenu.visible = false;
            _settingsMenu.visible = true;
        };
        quitButton.clicked += () =>
        {
            Debug.Log("Quit!");
            Application.Quit();
        };
    }

    private void InitializeSettingsMenu(VisualElement root)
    {
        var sensitivity = root.Q<Slider>("SensitivitySlider");
        var backButton = root.Q<Button>("BackButton");
        backButton.clicked += () =>
        {

            GameStore.Sensitivity = sensitivity.value;
            _mainMenu.visible = true;
            _settingsMenu.visible = false;
        };
    }
}
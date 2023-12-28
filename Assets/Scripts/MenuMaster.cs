using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuMaster : MonoBehaviour
{
    private UIDocument _ui;

    private void Start()
    {
        _ui = FindFirstObjectByType<UIDocument>();
        var startButton = _ui.rootVisualElement.Q<Button>("Start");
        var quitButton = _ui.rootVisualElement.Q<Button>("Quit");
        startButton.clicked += () => SceneManager.LoadScene(1);
        quitButton.clicked += () =>
        {
            Debug.Log("Quit!");
            Application.Quit();
        };
    }
}
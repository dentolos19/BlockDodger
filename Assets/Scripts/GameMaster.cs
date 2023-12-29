using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class GameMaster : MonoBehaviour
{
    private int _score;
    private VisualElement _scoreDisplay;
    private VisualElement _pauseMenu;
    private VisualElement _deathMenu;

    public float deathSlowMultiplier = 10;
    public UIDocument scoreDisplayDocument;
    public UIDocument gameMenusDocument;

    private void Start()
    {
        _scoreDisplay = scoreDisplayDocument.rootVisualElement;
        _pauseMenu = gameMenusDocument.rootVisualElement.Q<VisualElement>("PauseMenu");
        _deathMenu = gameMenusDocument.rootVisualElement.Q<VisualElement>("DeathMenu");
        _pauseMenu.Q<Button>("MenuButton").clicked += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        };
        _pauseMenu.Q<Button>("ResetButton").clicked += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        };
        _pauseMenu.Q<Button>("ResumeButton").clicked += () =>
        {
            Time.timeScale = 1;
            _pauseMenu.visible = false;
            _scoreDisplay.visible = true;
        };
        _deathMenu.Q<Button>("MenuButton").clicked += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        };
        _deathMenu.Q<Button>("RestartButton").clicked += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        };
        _scoreDisplay.Q<Button>("MenuButton").clicked += () =>
        {
            Time.timeScale = 0;
            _scoreDisplay.visible = false;
            _pauseMenu.visible = true;
        };
    }

    private IEnumerator EndGameCoroutine()
    {
        Time.timeScale /= deathSlowMultiplier;
        Time.fixedDeltaTime /= deathSlowMultiplier;
        yield return new WaitForSeconds(1 / deathSlowMultiplier);
        Time.timeScale = 0;
        // Time.fixedDeltaTime *= slowMultiplier;
        _scoreDisplay.visible = false;
        _deathMenu.visible = true;
    }

    public void EndGame()
    {
        StartCoroutine(EndGameCoroutine());
    }

    public void IncrementScore()
    {
        var scoreLabel = scoreDisplayDocument.rootVisualElement.Q<Label>("ScoreLabel");
        scoreLabel.text = (++_score).ToString();
    }
}
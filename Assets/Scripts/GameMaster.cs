using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameMaster : MonoBehaviour
{
    private int _score;

    public float slowMultiplier = 10;
    public UIDocument scoreDisplay;
    public UIDocument gameMenus;

    private void Start()
    {

        var pauseMenu = gameMenus.rootVisualElement.Q<VisualElement>("PauseMenu");
        pauseMenu.Q<Button>("MenuButton").clicked += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        };
        pauseMenu.Q<Button>("ResetButton").clicked += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        };
        pauseMenu.Q<Button>("ResumeButton").clicked += () =>
        {
            Time.timeScale = 1;
            pauseMenu.visible = false;
            scoreDisplay.rootVisualElement.visible = true;
        };

        var endMenu = gameMenus.rootVisualElement.Q<VisualElement>("EndMenu");
        endMenu.Q<Button>("MenuButton").clicked += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        };

        endMenu.Q<Button>("RestartButton").clicked += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        };

        scoreDisplay.rootVisualElement.Q<Button>("MenuButton").clicked += () =>
        {
            scoreDisplay.rootVisualElement.visible = false;
            Time.timeScale = 0;
            pauseMenu.visible = true;
        };
    }

    private IEnumerator EndGameCoroutine()
    {
        var originalTimeScale = Time.timeScale;
        var originalFixedDeltaTime = Time.fixedDeltaTime;
        Time.timeScale /= slowMultiplier;
        Time.fixedDeltaTime /= slowMultiplier;
        yield return new WaitForSeconds(1 / slowMultiplier);
        Time.timeScale = originalTimeScale;
        Time.fixedDeltaTime = originalFixedDeltaTime;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGame()
    {
        StartCoroutine(EndGameCoroutine());
    }

    public void IncrementScore()
    {
        var scoreLabel = scoreDisplay.rootVisualElement.Q<Label>("ScoreLabel");
        scoreLabel.text = (++_score).ToString();
    }
}
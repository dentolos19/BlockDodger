using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameMaster : MonoBehaviour
{
    private UIDocument _ui;
    private int _score;

    public float slowMultiplier = 10;

    private void Start()
    {
        _ui = FindFirstObjectByType<UIDocument>();
    }

    private IEnumerator EndGameCoroutine()
    {
        Time.timeScale /= slowMultiplier;
        Time.fixedDeltaTime /= slowMultiplier;
        yield return new WaitForSeconds(1 / slowMultiplier);
        Time.timeScale *= slowMultiplier;
        Time.fixedDeltaTime *= slowMultiplier;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncrementScore()
    {
        var scoreLabel = _ui.rootVisualElement.Q<Label>("Score");
        scoreLabel.text = (++_score).ToString();
    }

    public void EndGame()
    {
        StartCoroutine(EndGameCoroutine());
    }
}
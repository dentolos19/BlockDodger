using System.Collections;
using TMPro;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    private int _score;
    private bool _gameEnded;

    public float deathSlowness = 10;
    public TextMeshProUGUI scoreCounter;
    public GameObject menuBackground;
    public GameObject deathMenu;

    private IEnumerator RestartLevel()
    {
        Time.timeScale /= deathSlowness;
        Time.fixedDeltaTime /= deathSlowness;
        yield return new WaitForSeconds(1 / deathSlowness);
        Time.timeScale = 0;
        menuBackground.SetActive(true);
        deathMenu.SetActive(true);
    }

    public void IncrementScore()
    {
        _score++;
        scoreCounter.text = _score.ToString();
    }

    public void EndGame()
    {
        if (_gameEnded)
            return;
        StartCoroutine(nameof(RestartLevel));
        _gameEnded = true;
    }

}
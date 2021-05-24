using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{

    public TextMeshProUGUI currentScoreCounter;
    public TextMeshProUGUI highestScoreCounter;
    public GameObject leaderboardsButton;

    private void Start()
    {
        if (Player.Score > Game.Settings.HighestScore)
        {
            Game.Settings.HighestScore = Player.Score;
            Game.Settings.Save();
        }
        currentScoreCounter.text = "CURRENT SCORE: " + Player.Score;
        highestScoreCounter.text = "HIGHEST SCORE: " + Game.Settings.HighestScore;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
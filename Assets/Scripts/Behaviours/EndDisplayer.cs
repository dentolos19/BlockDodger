using TMPro;
using UnityEngine;

public class EndDisplayer : MonoBehaviour
{

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highestScoreText;

    private void Start()
    {
        if (Game.EndPassArgs > Game.Settings.HighestScore)
        {
            Game.Settings.HighestScore = Game.EndPassArgs;
            Game.Settings.Save();
        }
        currentScoreText.text = $"CURRENT SCORE: {Game.EndPassArgs}";
        highestScoreText.text = $"HIGHEST SCORE: {Game.Settings.HighestScore}";
    }

}
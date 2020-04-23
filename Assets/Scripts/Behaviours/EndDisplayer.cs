using TMPro;
using UnityEngine;

public class EndDisplayer : MonoBehaviour
{

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highestScoreText;

    private void Start()
    {
        if (Global.EndPassArgs > Global.Settings.HighestScore)
        {
            Global.Settings.HighestScore = Global.EndPassArgs;
            Global.Settings.Save();
        }
        currentScoreText.text = $"CURRENT SCORE: {Global.EndPassArgs}";
        highestScoreText.text = $"HIGHEST SCORE: {Global.Settings.HighestScore}";
    }

}
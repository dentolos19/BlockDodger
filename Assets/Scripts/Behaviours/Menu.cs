using System.IO;
<<<<<<< HEAD
using System.Runtime.InteropServices.WindowsRuntime;
=======
>>>>>>> DodgeTheBlocksOld/master
using GooglePlayGames;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject agreementMenu;

<<<<<<< HEAD
=======
    public GameObject leaderboardsButton;
    
>>>>>>> DodgeTheBlocksOld/master
    public Slider optionsSensitivity;
    public Toggle optionsMuteSounds;
    public Dropdown optionsControlType;

<<<<<<< HEAD
=======
    private void Awake()
    {
        if (Game.IsPlayServicesEnabled)
            leaderboardsButton.SetActive(true);
    }
    
>>>>>>> DodgeTheBlocksOld/master
    private void Start()
    {
        optionsSensitivity.value = Game.Settings.Sensitivity;
        optionsControlType.value = Game.Settings.ControlType;
        optionsMuteSounds.isOn = Game.Settings.MuteSounds;
        if (!Game.Settings.MuteSounds)
            Music.Instance.Play();
        if (Game.Settings.IsPrivacyPolicyAgreed)
            return;
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        agreementMenu.SetActive(true);
    }

    public void Save()
    {
        Game.Settings.Sensitivity = optionsSensitivity.value;
        Game.Settings.ControlType = optionsControlType.value;
        Game.Settings.MuteSounds = optionsMuteSounds.isOn;
        Game.Settings.Save();
        if (Game.Settings.MuteSounds)
            Music.Instance.Stop();
        else
            Music.Instance.Play();
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        agreementMenu.SetActive(false);
    }

    public void Play()
    {
<<<<<<< HEAD
        if (Game.IsPlayServicesEnabled)
        {
            var leaderboard = Social.CreateLeaderboard();
            leaderboard.id = GPGSIds.leaderboard_overall_high_scores;
            leaderboard.LoadScores(success =>
            {
                if (!success)
                    return;
                var value = (int)leaderboard.localUserScore.value;
                if (value > Game.Settings.HighestScore)
                {
                    Game.Settings.HighestScore = value;
                    return;
                }
                if (Game.Settings.HighestScore > value)
                    Social.ReportScore(Game.Settings.HighestScore, GPGSIds.leaderboard_overall_high_scores, success2 =>
                    {
                        if (success2)
                            Debug.Log("[GPGS] Posted to leaderboards!");
                        else
                            Debug.LogError("[GPGS] Unable to post to leaderboards!");
                    });
            });
        }
=======
>>>>>>> DodgeTheBlocksOld/master
        SceneManager.LoadScene(1);
    }

    public void GoToOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        agreementMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Agree()
    {
        Game.Settings.IsPrivacyPolicyAgreed = true;
        Game.Settings.Save();
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        agreementMenu.SetActive(false);
    }

    public void LearnMore()
    {
<<<<<<< HEAD
        Application.OpenURL("https://dennise.me/privacy");
=======
        Application.OpenURL("https://dentolos19.github.io/DodgeTheBlocks/privacy");
>>>>>>> DodgeTheBlocksOld/master
    }

    public void ShowLeaderboards()
    {
        Social.ShowLeaderboardUI();
    }

}
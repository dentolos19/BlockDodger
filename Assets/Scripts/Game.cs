using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.Advertisements;

public static class Game
{

    public static bool IsPlayServicesEnabled { get; private set; }
    public static Configuration Settings { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Startup()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Settings = Configuration.Load();
        if (Application.platform == RuntimePlatform.Android)
            Advertisement.Initialize("3569004");
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
            Advertisement.Initialize("3569005");
        // if (GooglePlayGames.OurUtils.PlatformUtils.Supported)
        //     Authenticate();
    }

    private static void Authenticate()
    {
        /*
        var config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(success =>
        {
            if (success)
            {
                IsPlayServicesEnabled = true;
                Debug.Log("[GPGS] Play Services Enabled Successfully!");
            }
            else
            {
                IsPlayServicesEnabled = false;
                Debug.LogError("[GPGS] Play Services Sign-in Failed!");
            }
        });
        */
    }
    
}
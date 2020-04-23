using UnityEngine;
using UnityEngine.Advertisements;

public static class Game
{

    public static int EndPassArgs { get; set; }

    public static int DeathAmount { get; set; }

    public static Configuration Settings { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Settings = Configuration.Load();
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                Advertisement.Initialize("3569004");
                break;
            case RuntimePlatform.IPhonePlayer:
                Advertisement.Initialize("3569005");
                break;
        }
    }

}
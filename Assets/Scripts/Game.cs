using UnityEngine;
using UnityEngine.Advertisements;

public static class Game
{
    
    public static Configuration Settings { get; private set; }
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Startup()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Settings = Configuration.Load();
        if (Application.platform == RuntimePlatform.Android)
            Advertisement.Initialize("3569004");
    }
    
}
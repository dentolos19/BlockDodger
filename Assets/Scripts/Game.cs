using UnityEngine;

public static class Game
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    private static void OnStartup()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
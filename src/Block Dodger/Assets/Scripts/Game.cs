using UnityEngine;

public static class Game
{

    private static float InitialTimeScale;
    private static float InitialFixedDeltaTime;

    public static void ResetTime()
    {
        Time.timeScale = InitialTimeScale;
        Time.fixedDeltaTime = InitialFixedDeltaTime;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnStartup()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        InitialTimeScale = Time.timeScale;
        InitialFixedDeltaTime = Time.fixedDeltaTime;
    }

}
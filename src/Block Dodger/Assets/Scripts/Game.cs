using UnityEngine;

public static class Game
{

    private static float InitialTimeScale;
    private static float InitialFixedDeltaTime;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnStartup()
    {
        InitialTimeScale = Time.timeScale;
        InitialFixedDeltaTime = Time.fixedDeltaTime;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public static void RestoreTimeSettings()
    {
        Time.timeScale = InitialTimeScale;
        Time.fixedDeltaTime = InitialFixedDeltaTime;
    }

}
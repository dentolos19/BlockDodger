using UnityEngine;

public static class Game
{

    public static int EndPassArgs { get; set; }

    public static Configuration Settings { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Settings = Configuration.Load();
    }

}
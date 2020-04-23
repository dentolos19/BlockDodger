using System;
using System.Net;
using UnityEngine;

public static class Global
{

    public static int EndPassArgs { get; set; }

    public static Configuration Settings { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Settings = Configuration.Load();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void CheckForUpdates()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
            return;
        if (Application.internetReachability == NetworkReachability.NotReachable)
            return;
        var client = new WebClient();
        var data = client.DownloadString("https://raw.githubusercontent.com/dentolos19/DodgeTheBlocks/master/VERSION");
        client.Dispose();
        if (Version.Parse(data) > Version.Parse(Application.version))
            Utilities.ShowToastAndroid("Updates are available.");
    }

}
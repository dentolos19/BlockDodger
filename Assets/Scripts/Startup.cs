using System;
using System.Net;
using UnityEngine;

public static class GameStartup
{

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Startup()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void CheckForUpdates()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
            return;
        if (Application.internetReachability == NetworkReachability.NotReachable)
            return;
        var client  = new WebClient();
        var data = client.DownloadString("https://raw.githubusercontent.com/dentolos19/DodgeTheBlocks/master/VERSION");
        client.Dispose();
        if (Version.Parse(data) > Version.Parse(Application.version))
            Utilities.ShowToastAndroid("Updates are available.");
    }

}
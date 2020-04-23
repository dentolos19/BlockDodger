using UnityEngine;

public static class Utilities
{

    public static void ShowToastAndroid(string message)
    {
        if (Application.platform != RuntimePlatform.Android)
            return;
        var player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var activity = player.GetStatic<AndroidJavaObject>("currentActivity");
        var toaster = new AndroidJavaClass("android.widget.Toast");
        activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            var toast = toaster.CallStatic<AndroidJavaObject>("makeText", activity, message, 0);
            toast.Call("show");
        }));
    }

}
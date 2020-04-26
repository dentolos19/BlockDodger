using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    private void Start()
    {
        var component = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicSound>();
        if (Game.Settings.MuteGameSounds)
            component.Stop();
        else
            component.Play();
    }
    
}
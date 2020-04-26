using UnityEngine;

public class MusicSound : MonoBehaviour
{

    private AudioSource _source;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _source = GetComponent<AudioSource>();
    }

    public void Play()
    {
        if (_source.isPlaying)
            return;
        _source.Play();
    }

    public void Stop()
    {
        _source.Stop();
    }

}
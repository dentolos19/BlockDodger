using UnityEngine;

public class Music : MonoBehaviour
{

    public static Music Instance { get; private set; }
    
    private AudioSource _source;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _source = GetComponent<AudioSource>();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (Game.Settings.MuteSounds)
            Stop();
    }

    public void Play()
    {
        if (!_source.isPlaying)
            _source.Play();
    }

    public void Stop()
    {
        if (_source.isPlaying)
            _source.Stop();
    }

}
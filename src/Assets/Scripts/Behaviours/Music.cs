using UnityEngine;

public class Music : MonoBehaviour
{

    public static Music Instance { get; private set; }
    
    private AudioSource mSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        mSource = GetComponent<AudioSource>();
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
        if (!mSource.isPlaying)
            mSource.Play();
    }

    public void Stop()
    {
        if (mSource.isPlaying)
            mSource.Stop();
    }

}
using UnityEngine;

public class Music : MonoBehaviour
{

    public static Music Instance { get; private set; }
    
<<<<<<< HEAD
    private AudioSource mSource;
=======
    private AudioSource _source;
>>>>>>> DodgeTheBlocksOld/master

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
<<<<<<< HEAD
        mSource = GetComponent<AudioSource>();
=======
        _source = GetComponent<AudioSource>();
>>>>>>> DodgeTheBlocksOld/master
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
<<<<<<< HEAD
        if (!mSource.isPlaying)
            mSource.Play();
=======
        if (!_source.isPlaying)
            _source.Play();
>>>>>>> DodgeTheBlocksOld/master
    }

    public void Stop()
    {
<<<<<<< HEAD
        if (mSource.isPlaying)
            mSource.Stop();
=======
        if (_source.isPlaying)
            _source.Stop();
>>>>>>> DodgeTheBlocksOld/master
    }

}
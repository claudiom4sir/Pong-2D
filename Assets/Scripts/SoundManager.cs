using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager singleton;

    [Header("Audio Source")]
    [SerializeField]
    AudioSource backgroud;
    [SerializeField]
    AudioSource hit;
    [SerializeField]
    AudioSource gameover;

    bool isAudioEnabled = true;

    void Awake()
    {
        if (singleton == null)
            singleton = this;
    }

    public void StartHit()
    {
        if(isAudioEnabled)
            hit.Play();
    }

    public void StartGameOver()
    {
        if(isAudioEnabled)
            gameover.Play();
    }

    public void ToggleAudio() // enables or disables audio source
    {
        isAudioEnabled = !isAudioEnabled;
        if (isAudioEnabled)
            backgroud.Play();
        else
            backgroud.Stop();
    }

    public bool IsAudioEnabled()
    {
        return isAudioEnabled;
    }

    public void DisableAllAudio() // it will invoked by GameManager, when you press QUIT button
    {
        isAudioEnabled = false;
    }
}

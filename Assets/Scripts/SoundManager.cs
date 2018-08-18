using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager singleton;

    [Header("Audio Source")]
    [SerializeField]
    AudioSource hit;
    [SerializeField]
    AudioSource gameover;

    void Awake()
    {
        if (singleton == null)
            singleton = this;
    }

    public void StartHit()
    {
        hit.Play();
    }

    public void StartGameOver()
    {
        gameover.Play();
    }
}

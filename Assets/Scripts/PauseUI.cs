using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{

    [SerializeField]
    Text soundText;

    void Start()
    {
        SetSoundText();  
    }

    void SetSoundText()
    {
        if (SoundManager.singleton.IsAudioEnabled())
            soundText.text = "SOUND OFF";
        else
            soundText.text = "SOUND ON";
    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        if (Time.timeScale == 1f)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void Resume()
    {
        Toggle();
    }

    public void Quit()
    {
        gameObject.SetActive(false);
        this.enabled = false;
        Time.timeScale = 1f;
        GameManager.singleton.Quit();
    }

    public void ToggleAudio()
    {
        SoundManager.singleton.ToggleAudio();
        SetSoundText();
    }
}

using UnityEngine;

public class PauseUI : MonoBehaviour
{

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
        Debug.Log("Quitting...");
        Application.Quit();
    }
}

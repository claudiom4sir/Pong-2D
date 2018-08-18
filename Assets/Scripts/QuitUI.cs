using System.Collections;
using UnityEngine;

public class QuitUI : MonoBehaviour {

    public void Quit()
    {
        gameObject.SetActive(true);
        StartCoroutine(CloseGame());
    }

    IEnumerator CloseGame()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Quitting...");
        Application.Quit();
    }

}

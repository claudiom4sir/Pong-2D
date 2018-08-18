using UnityEngine;
using System.Collections;

public class WelcomeUI : MonoBehaviour {

    [SerializeField]
    GameObject playerUI;

    void Start()
    {
        playerUI.SetActive(false);
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame() // used for start the game
    {
        yield return new WaitForSeconds(2f);
        playerUI.SetActive(true);
        gameObject.SetActive(false);
        GameManager.singleton.NotifyWelcomeUIDisabled();
    }
}

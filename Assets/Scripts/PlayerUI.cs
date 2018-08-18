using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    [SerializeField]
    Text startGameInfo;

    public void ToggleStartGameInfo() // startGameInfo shows text "Press SPACE BAR to start the game"
    {
        startGameInfo.enabled = !startGameInfo.IsActive();
    }
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager singleton;

    [SerializeField]
    Collider2D leftWall;
    [SerializeField]
    Collider2D rightWall;

    int scorePlayer1 = 0;
    int scorePlayer2 = 0;

    void Awake()
    {
        if (singleton == null)
            singleton = this;
    }

    public void IncreaseScore(string wall)
    {
        if (wall == "Left Wall")
            scorePlayer2++;
        else if (wall == "Right Wall")
            scorePlayer1++;
        else
            Debug.Log("You didn't hit right or left wall");
    }

    public int GetScore(string playerName)
    {
        if (playerName == "Player1")
            return scorePlayer1;
        else if (playerName == "Player2")
            return scorePlayer2;
        Debug.Log("playeName argument is wrong");
        return -1;
    }

    
}

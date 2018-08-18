using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager singleton;

    [Header("Walls")]
    [SerializeField]
    Collider2D leftWall;
    [SerializeField]
    Collider2D rightWall;

    [Header("Player's score text")]
    [SerializeField]
    Text textScorePlayer1;
    [SerializeField]
    Text textScorePlayer2;

    int scorePlayer1 = 0;
    int scorePlayer2 = 0;

    void Awake()
    {
        if (singleton == null)
            singleton = this;
    }

    public void IncreaseScore(string wall)
    {
        if (wall == "LeftWall")
            scorePlayer2++;
        else if (wall == "RightWall")
            scorePlayer1++;
        else
            Debug.Log("You didn't hit right or left wall");
        UpdateTextScore();
    }

    void UpdateTextScore()
    {
        textScorePlayer1.text = scorePlayer1.ToString();
        textScorePlayer2.text = scorePlayer2.ToString();
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

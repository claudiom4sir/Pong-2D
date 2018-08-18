using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager singleton;

    [SerializeField]
    GameObject ball;

    [Header("Walls")]
    [SerializeField]
    BoxCollider2D topWall;
    [SerializeField]
    BoxCollider2D leftWall;
    [SerializeField]
    BoxCollider2D rightWall;
    [SerializeField]
    BoxCollider2D bottomWall;


    [Header("Buttons")]
    [SerializeField]
    KeyCode startKey = KeyCode.Space;
    [SerializeField]
    KeyCode escKey = KeyCode.Escape;

    [Header("UI")]
    [SerializeField]
    PauseUI pauseUI;
    [SerializeField]
    PlayerUI playerUI;

    [Header("Players")]
    [SerializeField]
    PlayerController player;
    [SerializeField]
    ComputerController computer;

    bool isInGame = false;
    BallController ballController;

    void Awake()
    {
        if (singleton == null)
            singleton = this;
    }

    void Start()
    {
        pauseUI.enabled = false;
        #region("DrawWall")
        DrawHorizontalWall(topWall, 1f, 0f, 0f, 0f, new Vector3(0.5f, 1f, 0f));
        DrawHorizontalWall(bottomWall, 1f, 0f, 0f, 0f, new Vector3(0.5f, 0f, 0f));
        DrawVerticalWall(leftWall, 0f, 1f, 0f, 0f, new Vector3(0f, 0.5f, 0f));
        DrawVerticalWall(rightWall, 1f, 1f, 1f, 0f, new Vector3(1f, 0.5f, 0f));
        #endregion
        ballController = ball.GetComponent<BallController>();
        if (ballController == null)
            Debug.LogError("ballController in GamaManager is null");
    }

    void Update()
    {
        if (Input.GetKeyDown(escKey))
            pauseUI.Toggle();
        if (isInGame)
            return;
        if (Input.GetKeyDown(startKey))
        {
            StartGame();
        }
    }

    public bool IsInGame()
    {
        return isInGame;
    }

    public void AssignScore(string wallName)
    {
        ScoreManager.singleton.IncreaseScore(wallName);
        RestartGame();
    }

    void StartGame()
    {
        isInGame = true;
        ballController.BallStart();
        playerUI.ToggleStartGameInfo();
    }

    public void RestartGame() // it is used for restart the game
    {
        isInGame = false;
        ballController.ResetBall();
        ResetPlayerPosition();
        playerUI.ToggleStartGameInfo();
    }

    void ResetPlayerPosition()
    {
        player.ResetPosition();
        computer.ResetPosition();
    }

    // this method it's used to create horizontals box collider, in line with camera's viewport
    void DrawHorizontalWall(BoxCollider2D wall, float x2x, float x2y, float x1x, float x1y, Vector3 centerPosition)
    {
        Camera cam = Camera.main;
        float x2 = cam.ViewportToWorldPoint(new Vector3(x2x, x2y, 0f)).x;
        float x1 = cam.ViewportToWorldPoint(new Vector3(x1x, x1y, 0f)).x;
        wall.size = new Vector2(x2 - x1, 0.5f);
        Vector3 position = cam.ViewportToWorldPoint(centerPosition);
        wall.offset = new Vector2(position.x, position.y);
    }

    // this method it's used to create verticals box collider, in line with camera's viewport
    void DrawVerticalWall(BoxCollider2D wall, float y2x, float y2y, float y1x, float y1y, Vector3 centerPosition)
    {
        Camera cam = Camera.main;
        float y2 = cam.ViewportToWorldPoint(new Vector3(y2x, y2y, 0f)).y;
        float y1 = cam.ViewportToWorldPoint(new Vector3(y1x, y1y, 0f)).y;
        wall.size = new Vector2(0.5f, y2 - y1);
        Vector3 position = cam.ViewportToWorldPoint(centerPosition);
        wall.offset = new Vector2(position.x, position.y);
    }
}

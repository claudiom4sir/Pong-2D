using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour {

    [Header("Settings")]
    [SerializeField]
    Vector2 startPosition = Vector2.zero;
    [SerializeField]
    float startBallSpeed = 2.5f;

    float ballSpeed;
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballSpeed = startBallSpeed * 2;
    }

    public void BallStart()
    {
        float xDirection = Random.Range(0f, 1f);
        if (xDirection <= 0.5f)
            xDirection = -1f;
        else
            xDirection = 1f;
        float yDirection = Random.Range(-1f, 1f);
        Vector2 direction = (new Vector2(xDirection, yDirection)).normalized;
        rb.velocity = direction * startBallSpeed;
    }

    public void ResetBall()
    {
        rb.position = startPosition;
        rb.velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.singleton.StartHit();
        if (collision.collider.tag == "Player")
        {
            if (collision.collider.transform.position.x < 0f) // if x < 0f, it's left player
            {
                RandomDirection(0.5f, 1f);
            }
            else
                RandomDirection(-1f, -0.5f);
        }
    }

    // this method is used for gives unexpected behavior to the ball
    void RandomDirection(float minX, float maxX)
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(-1f, 1f);
        rb.velocity = new Vector2(x, y).normalized * ballSpeed;
    }

}

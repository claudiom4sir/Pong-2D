using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ComputerController : MonoBehaviour {

    [SerializeField]
    Rigidbody2D ball;

    [Header("Settings")]
    [SerializeField]
    float speed = 2.5f;
    [SerializeField]
    float sensibility = 0.3f;

    Rigidbody2D rb;
    Vector2 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.LogError("rb is null");
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (!GameManager.singleton.IsInGame())
            return;
        Move();
    }

    void Move()
    {
        float yBall = ball.position.y;
        if (yBall - rb.position.y > sensibility)
            Move(Vector2.up);
        else if(yBall - rb.position.y < -sensibility) 
            Move(Vector2.down); 
    }

    void Move(Vector2 direction)
    {
        Vector2 currentPosition = new Vector2(rb.transform.position.x, rb.transform.position.y);
        Vector2 newPosition = currentPosition + direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    public void ResetPosition()
    {
        rb.position = startPosition;
    }



}

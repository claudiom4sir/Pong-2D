using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    float speed = 5f;
    [SerializeField]
    KeyCode moveUp = KeyCode.UpArrow;
    [SerializeField]
    KeyCode moveDown = KeyCode.DownArrow;
    [SerializeField]
    float maxYMovement = 2.3f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey(moveUp))
            Move(Vector2.up);
        else if (Input.GetKey(moveDown))
            Move(Vector2.down);
    }

    void Move(Vector2 direction)
    {
        Vector2 currentPosition = new Vector2(rb.transform.position.x, rb.transform.position.y);
        Vector2 newPosition = currentPosition + direction * speed * Time.fixedDeltaTime;
        if(direction == Vector2.up)
        {
            if (newPosition.y <= maxYMovement)
                rb.MovePosition(newPosition);
        }
        else if(direction == Vector2.down)
        {
            if (newPosition.y >= -maxYMovement)
                rb.MovePosition(newPosition);
        }
    }

}

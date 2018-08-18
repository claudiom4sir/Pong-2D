using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    float speed = 5f;

    [Header("Buttons")]
    [SerializeField]
    KeyCode moveUp = KeyCode.UpArrow;
    [SerializeField]
    KeyCode moveDown = KeyCode.DownArrow;

    Rigidbody2D rb;
    Vector2 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (!GameManager.singleton.IsInGame())
            return;
        if(Input.GetKey(moveUp))
            Move(Vector2.up);
        else if (Input.GetKey(moveDown))
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

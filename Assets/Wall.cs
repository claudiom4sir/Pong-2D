using UnityEngine;

public class Wall : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Ball")
            return;
        GameManager.singleton.AssignScore(collision.name);
    }
}

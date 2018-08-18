using UnityEngine;

public class Wall : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Ball")
            return;
        SoundManager.singleton.StartGameOver();
        GameManager.singleton.AssignScore(gameObject.tag);
    }
}

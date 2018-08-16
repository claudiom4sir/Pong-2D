using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager singleton;

    void Awake()
    {
        if (singleton == null)
            singleton = this;
    }
}

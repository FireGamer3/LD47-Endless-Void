using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Debug.Log("Game Manager Instance already defined!");
            Destroy(this);
        }
    }
}

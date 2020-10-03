using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public TMP_Text Score_Text;
    private int LastUpdateScore = 0;
    public int score = 0;

    public void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Debug.Log("Game Manager Instance already defined!");
            Destroy(this);
        }
    }

    public void Update() {
        if (score != LastUpdateScore) {
            Score_Text.text = "Score: " + score;
            LastUpdateScore = score;
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public bool allowSpawning = true;

    public TMP_Text Score_Text;
    public TMP_Text health;
    public Slider healthslider;
    public GameObject PlayerPrefab;
    private GameObject player;

    private int LastUpdateScore = 0;
    public int score = 0;

    public int hp = 2;
    public int maxHp = 2;

    public void TakeHit() {
        hp -= 1;
        if (hp == 0) {
            Destroy(player);
            allowSpawning = false;
        }
    }
    public void Heal(int amt = 1) {
        hp += amt;
        if (hp > maxHp) {
            hp = maxHp;
        }
    }
    public void setMaxHp(int amt = 2) {
        maxHp = amt;
        if (hp > maxHp) {
            hp = maxHp;
        }
    }

    public void Awake() {
        if (instance == null) {
            instance = this;
            player = Instantiate(PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
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
        if (healthslider.value != hp) {
            healthslider.value = hp;
            health.text = hp + "/2";
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    private ManueInteractions menuInteractions;

    public bool allowSpawning = true;

    private AudioSource sound_source;
    public AudioClip deathSound;
    public AudioClip hitSound;
    public TMP_Text Score_Text;
    public TMP_Text health;
    public Slider healthslider;
    public GameObject PlayerPrefab;
    private GameObject player;
    public GameObject gameoverScreen;

    private int LastUpdateScore = 0;
    public int score = 0;

    public int hp = 2;
    public int maxHp = 2;

    public void playHitSound() {
        sound_source.PlayOneShot(hitSound);
    }

    public void ResetGame() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void goToMainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void TakeHit() {
        playHitSound();
        hp -= 1;
        if (hp == 0) {
            Destroy(player);
            allowSpawning = false;
            gameoverScreen.SetActive(true);
            sound_source.PlayOneShot(deathSound);
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
        healthslider.maxValue = amt;
        if (hp > maxHp) {
            hp = maxHp;
        }
    }

    public void Awake() {
        if (instance == null) {
            instance = this;
            player = Instantiate(PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            sound_source = gameObject.AddComponent<AudioSource>();


            menuInteractions = new ManueInteractions();
            menuInteractions.Menus.Accept.performed += _ => HandleButtonPress(0);
            menuInteractions.Menus.Back.performed += _ => HandleButtonPress(1);
            menuInteractions.Enable();
        } else if (instance != this) {
            Debug.Log("Game Manager Instance already defined!");
            Destroy(this);
        }
    }
    private void OnDisable() {
        menuInteractions.Disable();
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
    private void HandleButtonPress(int type) {
        if (gameoverScreen.activeSelf) {
            switch (type) {
                case 0:
                    ResetGame();
                    break;
                case 1:
                    goToMainMenu();
                    break;
                default:
                    break;
            }
        }
    }
}

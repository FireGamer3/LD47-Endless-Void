using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public static MenuManager instance;
    //I just now noticed that this is misspelled, oh well
    private ManueInteractions menuInteractions;
    private int page = 0;

    public GameObject mainMenue;
    public GameObject storyControls;

    public void Awake() {
        if (instance == null) {
            instance = this;
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
    public void MoveToStory() {
        mainMenue.SetActive(false);
        storyControls.SetActive(true);
        page = 1;
    }
    public void MoveToMain() {
        mainMenue.SetActive(true);
        storyControls.SetActive(false);
        page = 0;
    }
    public void LoadGame() {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame() {
        Application.Quit();
    }
    private void HandleButtonPress(int type) {
        if (page == 0) {
            switch (type) {
                case 0:
                    MoveToStory();
                    break;
                case 1:
                    QuitGame();
                    break;
                default:
                    break;
            }
        } else {
            switch (type) {
                case 0:
                    LoadGame();
                    break;
                case 1:
                    MoveToMain();
                    break;
                default:
                    break;
            }
        }
    }
}

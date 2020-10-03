using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    private float leftBound, rightBound;
    private float diffTimerLeft = 10f;
    public float diff = 0.5f;
    private float timeLeft = 1f;

    public GameObject[] enemies;

    private void Awake() {
        leftBound = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + 0.4f;
        rightBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - 0.4f;
    }

    void Start() {
        timeLeft = Random.Range(0f * diff, 4f * diff);
    }


    void Update() {
        timeLeft -= Time.deltaTime;
        if (diff > 0.011f) {
            diffTimerLeft -= Time.deltaTime;
        }
        if (timeLeft <= 0f) {
            timeLeft = Random.Range(0f * diff, 4f * diff);
            GameObject go = Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(Random.Range(leftBound, rightBound), -7.7f, 0), Quaternion.identity);
            go.transform.parent = this.transform;
        }
        if (diffTimerLeft <= 0f && diff > 0.01f) {
            diff -= 0.01f;
            diffTimerLeft = 10f;
        }
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject spriteRender;
    public float moveSpeed = 3f;
    public float rotationSpeed = 1f;

    private float TopBound;

    private void Awake() {
        TopBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0)).y;
    }

    void Start() {
        rotationSpeed = Random.Range(0f, 1f);
        moveSpeed = Random.Range(2f, 4f);
    }
    void Update() {
        transform.Translate(new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime);

        if (spriteRender != null) {
            spriteRender.transform.Rotate(new Vector3(0, 0, rotationSpeed));
        }
    }
    private void LateUpdate() {
        if (transform.position.y > (TopBound + 5f)) {
            Vector3 newPos = new Vector3(transform.position.x, -7.7f, 0);
            transform.position = newPos;
        }
    }
}

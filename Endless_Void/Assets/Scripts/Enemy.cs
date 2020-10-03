using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject spriteRender;
    public Collider2D collision;

    public float moveSpeed = 3f;
    public float rotationSpeed = 1f;

    private float xdir;
    private float TopBound, LeftBound, RightBound;

    private void Awake() {
        TopBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0)).y;
        LeftBound = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0)).x;
        RightBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, 0)).x;
    }

    void Start() {
        xdir = Random.Range(-1f, 1f);
        rotationSpeed = Random.Range(-1f, 1f);
        moveSpeed = Random.Range(2f, 4f);
    }
    void Update() {
        transform.Translate(new Vector3(xdir, 1, 0) * moveSpeed * Time.deltaTime);

        if (spriteRender != null) {
            spriteRender.transform.Rotate(new Vector3(0, 0, rotationSpeed));
        }
    }
    private void LateUpdate() {
        if (transform.position.y > (TopBound + 3f)) {
            Vector3 newPos = new Vector3(transform.position.x, -7.7f, 0);
            transform.position = newPos;
        }
        if (transform.position.x > (RightBound + 1f)) {
            Vector3 newPos = new Vector3((LeftBound - 0.9f), transform.position.y, 0);
            transform.position = newPos;
        }
        if (transform.position.x < (LeftBound - 1f)) {
            Vector3 newPos = new Vector3((RightBound + 0.9f), transform.position.y, 0);
            transform.position = newPos;
        }
    }

    public void CollisionHandler(Collider2D col) {
        if (col.gameObject.tag == "Bullet") {
            GameManager.instance.playHitSound();
            GameManager.instance.score += Random.Range(1, 15);
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Player") {
            GameManager.instance.playHitSound();
            GameManager.instance.TakeHit();
            Destroy(this.gameObject);
        }
    }
}

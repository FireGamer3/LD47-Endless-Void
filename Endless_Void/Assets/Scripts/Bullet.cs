using UnityEngine;

public class Bullet : MonoBehaviour {
    private float LeftBound, RightBound, TopBound, BottomBound;
    private Vector3 moveDirection;
    private float moveSpeed = 7f;

    public bool MoveToPoint = false;

    private void Awake() {
        TopBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0)).y + 1f;
        BottomBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)).y - 1f;
        LeftBound = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0)).x - 1f;
        RightBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, 0)).x + 1f;
    }

    private void Update() {
        if (!MoveToPoint) {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, moveDirection * 1000f, moveSpeed * Time.deltaTime);
        }
    }

    public void setMoveDir(Vector3 dir) {
        moveDirection = dir;
    }

    private void LateUpdate() {
        if (transform.position.x > RightBound) {
            Destroy(gameObject);
        }
        if (transform.position.x < LeftBound) {
            Destroy(gameObject);
        }
        if (transform.position.y > TopBound) {
            Destroy(gameObject);
        }
        if (transform.position.y < BottomBound) {
            Destroy(gameObject);
        }
    }
}

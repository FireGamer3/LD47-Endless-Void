using UnityEngine;

public class Player : MonoBehaviour {
    private PlayerMovement movement;

    private Vector3 MoveDirection = new Vector3();

    [SerializeField] private float moveSpeed = 3f;

    private float LeftBound, RightBound, TopBound, BottomBound;

    private void Awake() {
        TopBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0)).y;
        BottomBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)).y;
        LeftBound = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0)).x;
        RightBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, 0)).x;

        movement = new PlayerMovement();
        movement.Player.Movement.performed += _ => Movement_performed(_.ReadValue<Vector2>());
        movement.Enable();
    }

    void Start() {

    }
    private void OnDisable() {
        movement.Disable();
    }

    void Update() {
        if ((transform.position.x - 1f) <= LeftBound) {
            if (MoveDirection.x < 0f) MoveDirection.x = 0f;
        } else if ((transform.position.x + 1f) >= RightBound) {
            if (MoveDirection.x > 0f) MoveDirection.x = 0f;
        }
        if ((transform.position.y - 1f) <= BottomBound) {
            if (MoveDirection.y < 0f) MoveDirection.y = 0f;
        } else if ((transform.position.y + 1f) >= TopBound) {
            if (MoveDirection.y > 0f) MoveDirection.y = 0f;
        }
        transform.Translate(MoveDirection * moveSpeed * Time.deltaTime);
    }
    private void Movement_performed(Vector2 movement) {
        Vector3 actualMovement = new Vector3(movement.x, movement.y, 0);
        actualMovement.Normalize();
        MoveDirection = actualMovement;
    }
}

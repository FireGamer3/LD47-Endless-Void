using UnityEngine;

public class Player : MonoBehaviour {
    private PlayerMovement movement;

    private Vector3 MoveDirection = new Vector3();

    [SerializeField] private float moveSpeed = 3f;
    private void Awake() {
        movement = new PlayerMovement();
        movement.Player.Movement.performed += _ => Movement_performed(_.ReadValue<Vector2>());
        movement.Enable();
    }

    void Start() {

    }
    private void OnDestroy() {
        movement.Disable();
    }

    void Update() {
        transform.Translate(MoveDirection * moveSpeed * Time.deltaTime);
    }
    private void Movement_performed(Vector2 movement) {
        Vector3 actualMovement = new Vector3(movement.x, movement.y, 0);
        actualMovement.Normalize();
        MoveDirection = actualMovement;
    }
}

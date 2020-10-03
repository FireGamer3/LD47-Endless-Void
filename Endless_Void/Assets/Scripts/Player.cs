﻿using UnityEngine;

public class Player : MonoBehaviour {
    private PlayerMovement movement;

    private Vector3 MoveDirection = new Vector3();

    public AudioSource sound_source;
    public AudioClip[] shoot_sounds;

    [SerializeField] private float moveSpeed = 3f;

    private float LeftBound, RightBound, TopBound, BottomBound;

    public GameObject BulletPrefab;

    private void Awake() {
        TopBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0)).y;
        BottomBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)).y;
        LeftBound = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0)).x;
        RightBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, 0)).x;

        movement = new PlayerMovement();
        movement.Player.Movement.performed += _ => Movement_performed(_.ReadValue<Vector2>());
        movement.Player.mouse_shoot.performed += _ => MouseClick();
        movement.Enable();

        sound_source = gameObject.AddComponent<AudioSource>();
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

    private void MouseClick() {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float BoundSpace = 1f;
        Vector3 dir = new Vector3(0, 0, 0);
        if (worldPos.x >= (transform.position.x + BoundSpace)) {
            dir.x = 1f;
        } else if (worldPos.x <= (transform.position.x - BoundSpace)) {
            dir.x = -1f;
        }
        if (worldPos.y >= (transform.position.y + BoundSpace)) {
            dir.y = 1f;
        } else if (worldPos.y <= (transform.position.y - BoundSpace)) {
            dir.y = -1f;
        }
        if (dir.x == 0f && dir.y == 0f) {
            dir.x = 1f;
        }
        GameObject go = Instantiate(BulletPrefab, transform.position + dir, Quaternion.identity);
        sound_source.PlayOneShot(shoot_sounds[Random.Range(0, shoot_sounds.Length)]);
        go.GetComponent<Bullet>().setMoveDir(dir);
    }
}

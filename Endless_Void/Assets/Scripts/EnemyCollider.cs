using UnityEngine;

public class EnemyCollider : MonoBehaviour {
    private Enemy e;
    void Start() {
        e = this.GetComponentInParent<Enemy>();
        if (e == null) {
            Debug.LogError("No Enemy Found!");
            Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        e.CollisionHandler(col);
    }
}

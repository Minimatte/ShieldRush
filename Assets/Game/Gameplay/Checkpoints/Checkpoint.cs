using UnityEngine;

public class Checkpoint : MonoBehaviour {

    bool visited = false;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player") && !visited) {
            visited = true;
            GameController.lastCheckpoint = this;
        }
    }
}

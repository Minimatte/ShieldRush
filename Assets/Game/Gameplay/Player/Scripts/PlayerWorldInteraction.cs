using UnityEngine;
using System.Collections;

public class PlayerWorldInteraction : MonoBehaviour {
    [SerializeField, Tooltip("This is what the player can find if he presses the interact button")]
    private LayerMask hitMask;
    void Update() {
        if (Input.GetButtonDown("Interact")) {
            Collider[] hits = Physics.OverlapSphere(transform.position, 3, hitMask);
            
            foreach (Collider hit in hits) {
                if (hit.gameObject.GetComponent<Interactable>()) {
                    hit.gameObject.GetComponent<Interactable>().Interact();
                }
            }

        }
    }
}

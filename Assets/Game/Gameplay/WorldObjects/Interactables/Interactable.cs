using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public abstract class Interactable : MonoBehaviour {
    void Awake() {
        if (gameObject.layer != LayerMask.NameToLayer("Interactable")) {

            string oldLayer = LayerMask.LayerToName(gameObject.layer);
            gameObject.layer = LayerMask.NameToLayer("Interactable");
            Debug.LogWarning("Changed interactable " + name + "'s layer to interactable instead of " + oldLayer);
        }
    }

    public abstract void Interact();

}

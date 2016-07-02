using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public abstract class Pickup : MonoBehaviour {

    public GameObject pickupParticle;
    public AudioClip pickupSound;

    protected bool canPickup = false;
    public float canBePickedUpDelay = 1;

    void Start() {
        StartCoroutine(WaitUntilPickable());
    }

    void OnTriggerEnter(Collider other) {
        if (!canPickup)
            return;
        if (other.tag == "Player") {
            TriggerPickup(other);
            ScreenEffects.HealthUpEffect();
            if (pickupSound != null)
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            if (pickupParticle != null) {
                GameObject go = (GameObject)Instantiate(pickupParticle, GameController.Player.transform.position, Quaternion.Euler(-90, 0, 0));
                go.transform.SetParent(GameController.Player.transform);
            }
        }

    }
    public abstract void TriggerPickup(Collider other);

    private IEnumerator WaitUntilPickable() {
        yield return new WaitForSeconds(canBePickedUpDelay);
        canPickup = true;
    }

}

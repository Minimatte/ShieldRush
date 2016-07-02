using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class CameraVolume : MonoBehaviour {

    public float time;
    public float delay;
    public GameObject target;

    public bool oneTimeUse = true;
    private bool used = false;

    void Awake() {
        if (!GetComponent<Collider>().isTrigger)
            GetComponent<Collider>().isTrigger = true;

        if (target == null)
            throw new System.Exception("You have to specify a target on the camera volume (" + name + ")");
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (oneTimeUse) { // if its one time use
                if (!used) {
                    used = true;
                    StartCoroutine(MoveCamOverTime(time, delay));
                }
            } else { // if we can activate it more than one time
                used = true;
                StartCoroutine(MoveCamOverTime(time, delay));
            }
        }
    }


    IEnumerator MoveCamOverTime(float time, float delay) {
        if (GameController.Player != null) {

            GameController.Player.GetComponent<Player>().healthProperty.invincible = true;
            GameController.Player.GetComponent<Player>().movementProperties.canMove = false;
        }
        Camera.main.GetComponent<CameraMovement>().player = target;
        yield return new WaitForSeconds(time / 2);
        Camera.main.GetComponent<CameraMovement>().player = GameController.Player;
        if (GameController.Player != null) {

            GameController.Player.GetComponent<Player>().movementProperties.canMove = true;
            GameController.Player.GetComponent<Player>().healthProperty.invincible = false;
            GameController.Player.GetComponent<Player>().movementProperties.movementSpeedMultiplier = 1;
        }
    }

}

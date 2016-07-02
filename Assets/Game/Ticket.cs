using UnityEngine;
using System.Collections;
using System;

public class Ticket : Interactable {
    private Transform MoveToThis;

    private Transform player;
    private bool isDone = false;
    private IEnumerator MovePlayer() {
        do {
            player.GetComponent<Player>().unitMesh.LookAt(MoveToThis);
            Vector3 loc = MoveToThis.position - player.position;
            player.GetComponent<CharacterController>().SimpleMove(loc.normalized * player.GetComponent<Player>().movementProperties.movementSpeedBase);
            yield return 0;
        } while (Vector3.Distance(player.position, MoveToThis.position) > 1);
        player.GetComponent<Player>().unitMesh.GetComponent<Animator>().SetFloat("Speed", 0);

    }

    public override void Interact() {
        if (isDone)
            return;

        isDone = true;
        //MoveToThis = GameObject.FindGameObjectWithTag("RunTarget").transform;
        GameController.FadeToBlack();
        PlayerMovement.PlayerActive = false;
        player = GameController.Player.transform;
        UIManager.HideUI();
        Camera.main.GetComponent<CameraMovement>().camSize = 30;
        Camera.main.GetComponent<CameraMovement>().lerpSpeed = 0.5f;
        Camera.main.GetComponent<CameraMovement>().playerVelocity = 3;
        //StartCoroutine(MovePlayer());
        //player.GetComponent<Player>().unitMesh.GetComponent<Animator>().SetFloat("Speed", 1);
        player.GetComponent<Player>().unitMesh.GetComponent<Animator>().SetTrigger("Celebrate");
    }
}

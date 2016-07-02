using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {
    public static bool UseController = false;

    public GameObject UI;

    void Update() {

        if (Input.GetJoystickNames().Length > 0 && Input.GetJoystickNames()[0] == "")
            UseController = false;
        else
            UseController = true;

        if (Input.GetKeyDown(KeyCode.F12)) {
            UseController = !UseController;
            print("Using controller: " + UseController);
        }
        if (Input.GetKeyDown(KeyCode.F11)) {
            UI.SetActive(false);
        }
    }
}

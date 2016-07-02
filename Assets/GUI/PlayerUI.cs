using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    public Image holoBar;

    public void TurnOnHolobar() {
        holoBar.enabled = true;
    }
}

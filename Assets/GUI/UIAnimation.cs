using UnityEngine;
using System.Collections;

public class UIAnimation : MonoBehaviour {

    public void TurnOffAnimator() {
        GetComponent<Animator>().enabled = false;
        GetComponent<RectTransform>().sizeDelta = new Vector2(64, 64);
    }
}

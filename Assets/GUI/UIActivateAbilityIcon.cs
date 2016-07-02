using UnityEngine;
using System.Collections;

public class UIActivateAbilityIcon : MonoBehaviour {

    public GameObject iconbackground;
    public GameObject iconfrontend;

    void OnEnable() {
        iconbackground.SetActive(true);
        iconfrontend.SetActive(true);
    }

    void OnDisable() {
        iconbackground.SetActive(false);
        iconfrontend.SetActive(false);
    }

}

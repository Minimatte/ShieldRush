using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIChargeBar : MonoBehaviour {

    public Image chargeBar;

    public Abilities ability;

    void Update() {

        switch (ability) {
            case Abilities.Bash:
                chargeBar.fillAmount = Mathf.Lerp(chargeBar.fillAmount, GameController.Player.GetComponent<ShieldBash>().power / 2,5 * Time.deltaTime);
                break;
            case Abilities.Charge:
                chargeBar.fillAmount = Mathf.Lerp(chargeBar.fillAmount, GameController.Player.GetComponent<ShieldCharge>().power / 2, 5 * Time.deltaTime);
                break;
        }


    }
}

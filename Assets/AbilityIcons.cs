using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityIcons : MonoBehaviour {

    public Sprite chargeIconInActive;
    public Sprite chargeIconActive;
    public Sprite slamIconInActive;
    public Sprite slamIconActive;
    public Sprite reflectIconInActive;
    public Sprite reflectIconActive;

    public Image chargeIcon;
    public Image slamIcon;
    public Image reflectIcon;

    private ShieldProperties shield;

    void Start() {
        shield = GameController.Player.GetComponent<Player>().shieldProperties;
    }

    void Update() {

        if (shield == null)
            shield = GameController.Player.GetComponent<Player>().shieldProperties;

        if (GameController.isPaused)
            return;
        if (GameController.Player == null)
            return;

        Player p = GameController.Player.GetComponent<Player>();
        if (p != null) {
            ShieldCharge charge = GameController.Player.GetComponent<ShieldCharge>();
            if (p.GetComponent<PlayerAttack>().shieldActive && p.shieldProperties.isAlive && shield.currentShieldHealth >= charge.modifiedCost * shield.maxShieldHealth) {
                chargeIcon.sprite = chargeIconActive;

            } else {

                chargeIcon.sprite = chargeIconInActive;
            }

            ShieldBash reflect = p.GetComponent<ShieldBash>();
            if (p.GetComponent<PlayerAttack>().shieldActive && p.shieldProperties.isAlive && shield.currentShieldHealth >= reflect.modifiedCost * shield.maxShieldHealth) {
                reflectIcon.sprite = reflectIconActive;

            } else {

                reflectIcon.sprite = reflectIconInActive;
            }

            EMP emp = p.GetComponent<EMP>();

            float chargeMod = charge.abilityProperties.ModifiedCooldownPercentage;
            float empSlam = emp.abilityProperties.ModifiedCooldownPercentage;
            float reflectMod = reflect.abilityProperties.ModifiedCooldownPercentage;
            if (empSlam == 0 && shield.currentShieldHealth >= emp.shieldCost * shield.maxShieldHealth)
                slamIcon.sprite = slamIconActive;
            else
                slamIcon.sprite = slamIconInActive;

            reflectIcon.fillAmount = 1 - reflectMod;
            chargeIcon.fillAmount = 1 - chargeMod;
            slamIcon.fillAmount = 1 - empSlam;
        }
    }
}

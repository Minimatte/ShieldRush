using UnityEngine;
using System.Collections;

public class ScreenEffects : MonoBehaviour {

    static Animator animStatic;
    public Animator anim;

    void Awake() {
        animStatic = anim;
    }

    public static void TakeDamageEffect() {
        animStatic.SetTrigger("TakeDamage");
    }
    public static void HealthUpEffect() {
        animStatic.SetTrigger("HealthUp");
    }
    public static void ShieldOnEffect(bool shieldOn) {
        animStatic.SetBool("ShieldOn", shieldOn);
    }
}

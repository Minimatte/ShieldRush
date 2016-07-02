using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour {

    public static ShieldedEnemy boss;
    public static GameObject instance;
    public Image healthbar, healthbarEffect;

    void Awake() {
        instance = transform.GetChild(0).gameObject;
        instance.SetActive(false);
    }

    void Update() {
        if (boss != null && boss.healthProperty.isAlive) {
            float targetHp = boss.healthProperty.currentHealth / boss.healthProperty.maxHealth;
            healthbar.fillAmount = targetHp;

            float targetHpEffect = boss.healthProperty.currentHealth / boss.healthProperty.maxHealth;
            healthbarEffect.fillAmount = Mathf.Lerp(healthbarEffect.fillAmount, targetHpEffect, 2 * Time.deltaTime);
        } else
            transform.GetChild(0).gameObject.SetActive(false);
    }
}

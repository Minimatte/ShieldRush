using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    Image healthBar;
    [SerializeField]
    Animation portrait;

    private Color targetColor;

    public ParticleSystem hitParticles;

    void Start() {
        targetColor = healthBar.color;
        GameController.Player.GetComponent<Player>().healthBar = this;
    }

    void Update() {
        //portrait.SetFloat("Damage", healthBar.fillAmount);
        /*heart.speed = 1f / healthBar.fillAmount;

        if (heart.speed > 5)
        {
            heart.speed = 5;
        }*/

        if (healthBar.fillAmount <= 1) {
            targetColor = Color.green;
        }

        if (healthBar.fillAmount <= 0.6f) {
            targetColor = Color.yellow;
        }

        if (healthBar.fillAmount <= 0.3f) {
            targetColor = Color.red;
        }

        healthBar.color = Color.Lerp(healthBar.color, targetColor, Time.deltaTime * 4);
    }

    public void PlayParticles() {
        portrait.GetComponent<Animation>().Play();
        hitParticles.Play();
    }
}

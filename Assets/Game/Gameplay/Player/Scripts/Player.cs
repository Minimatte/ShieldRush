using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerWorldInteraction))]
public class Player : UnitProperties {

    public RollProperties rollProperties;
    public ShieldProperties shieldProperties;

    public Companion companion;
    internal HealthBar healthBar;
    public GameObject ragdoll;
    private IEnumerator shieldRegenWaitCoroutine;
    private Animator anim;

    public Animator ShieldAnimator;
    void Awake() {
        anim = unitMesh.GetComponent<Animator>();
    }

    public override void TakeDamage(float damage, UnitProperties damageDealer) {

        float dot = Vector3.Dot(unitMesh.forward, damageDealer.gameObject.transform.forward);
        anim.SetInteger("TakeDamage", Mathf.RoundToInt(dot));
        anim.SetTrigger("TakeDamageTrigger");

        UIManager.TakeDamageAnimation();
        ScreenEffects.TakeDamageEffect();

        base.TakeDamage(damage, damageDealer);
        Camera.main.GetComponent<CameraMovement>().ShakeCamera(0.1f, 0.3f);

    }
    protected override void CheckIfAlive() {
        if (healthProperty.isAlive == false) {
            UIManager.ShowRespawnUI();
        }

        base.CheckIfAlive();
    }

    protected override void UpdateProperties() {

        if (shieldProperties.isRegenerating) {
            shieldProperties.currentShieldHealth += Time.deltaTime * shieldProperties.shieldRegeneration;
            shieldProperties.currentShieldHealth = Mathf.Clamp(shieldProperties.currentShieldHealth, 0, shieldProperties.maxShieldHealth);

        }
    }

    protected override void DestroyObject() {

        ragdoll.transform.SetParent(null);
        ragdoll.SetActive(true);

        CameraMovement cm = Camera.main.GetComponent<CameraMovement>();
        cm.player = ragdoll;
        cm.camSize = cm.camSize / 2;

        foreach (Rigidbody r in ragdoll.GetComponentsInChildren<Rigidbody>()) {
            r.AddForce(Vector3.up * Random.Range(3000, 6000));
        }
        GameController.ragdoll = ragdoll;
        Camera.main.GetComponent<AudioListener>().enabled = true;
        base.DestroyObject();
    }

    private IEnumerator WaitForShieldRegen() {
        yield return new WaitForSeconds(shieldProperties.shieldRegenerationDelay);
        shieldProperties.isRegenerating = true;
    }


    public bool HasShield(float shieldCost) {
        if (shieldProperties.currentShieldHealth < shieldCost) {
            UIManager.LowManaAnimation();
            return false;
        } else {
            return true;
        }
    }

    public void TakeShieldDamage(float damage, ContactPoint hitLocation) {
        if (shieldProperties.isAlive) {
            shieldProperties.currentShieldHealth -= damage;
            shieldProperties.isRegenerating = false;

            Destroy(Instantiate(shieldProperties.shieldHitParticle, hitLocation.point, Quaternion.identity), 1f);
            ShieldAnimator.SetTrigger("TakeDamage");
        }
        if (shieldRegenWaitCoroutine != null)
            StopCoroutine(shieldRegenWaitCoroutine);
        shieldRegenWaitCoroutine = WaitForShieldRegen();
        StartCoroutine(shieldRegenWaitCoroutine);

    }

    public void TakeShieldDamage(float damage) {
        if (shieldProperties.isAlive) {
            shieldProperties.currentShieldHealth -= damage;
            shieldProperties.isRegenerating = false;
            
        }
        if (shieldRegenWaitCoroutine != null)
            StopCoroutine(shieldRegenWaitCoroutine);
        shieldRegenWaitCoroutine = WaitForShieldRegen();
        StartCoroutine(shieldRegenWaitCoroutine);

    }

}
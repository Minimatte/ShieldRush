using UnityEngine;
using System.Collections;
using System;

public class ShieldCharge : Ability {
    private const float checkDistance = 0.7f;
    private const int chargeSpeed = 100;
    private const int maxChargeTries = 50;
    private RollProperties rollProperties;
    private ShieldProperties shieldProperties;
    private Player playerProperties;

    public bool isCharging = false;
    public GameObject particlePrefab;

    [SerializeField]
    private AudioSource shieldChargeUpAudio;
    [SerializeField]
    private AudioSource shieldChargeAudio;

    [SerializeField]
    private AudioClip rollDodgeSound;

    public float unmodifiedCost = 0.25f;
    public float modifiedCost = 0.33f;

    public GameObject chargeupEffect;

    public float power = 0;

    private Animator anim;
    private Animator playerAnim;
    public GameObject shieldObject;
    void Start() {
        anim = shieldObject.GetComponent<Animator>();
        playerProperties = GetComponent<Player>();
        playerAnim = playerProperties.unitMesh.GetComponent<Animator>();
        rollProperties = playerProperties.rollProperties;
        shieldProperties = playerProperties.shieldProperties;
    }

    public override void UseAbility(bool modified) {
        if (abilityProperties.hasLearnt && playerProperties.shieldProperties.isAlive)
            if (modified && abilityProperties.upgraded && playerProperties.HasShield(shieldProperties.maxShieldHealth * modifiedCost) && !ShieldBash.isCharging) {
                if (abilityProperties.ModifiedCooldownReady) {
                    anim.SetTrigger("Charge");
                    playerProperties.TakeShieldDamage(shieldProperties.maxShieldHealth * modifiedCost);
                    UseAbilityRoll(modified);
                }
            } else {
                if (abilityProperties.UnmodifiedCooldownReady && !playerProperties.shieldProperties.shieldActive && playerProperties.HasShield(shieldProperties.maxShieldHealth * unmodifiedCost)) {
                    UseAbilityRoll(modified);
                    abilityProperties.unmodifiedCurrentCooldown = abilityProperties.unmodifiedMaxCooldown;
                    playerProperties.TakeShieldDamage(shieldProperties.maxShieldHealth * unmodifiedCost);
                }
            }
    }

    void UseAbilityRoll(bool modified) {
        Vector3 dxy = new Vector3(Input.GetAxisRaw("Horizontal") * playerProperties.movementProperties.movementSpeedBase * playerProperties.movementProperties.movementSpeedMultiplier, 0.0f, Input.GetAxisRaw("Vertical") * playerProperties.movementProperties.movementSpeedBase * playerProperties.movementProperties.movementSpeedMultiplier);
        dxy = Quaternion.Euler(0, Camera.main.transform.localRotation.eulerAngles.y, 0) * dxy;
        if (modified)
            StartCoroutine(WaitForRelease(modified));
        else
            roll(rollProperties.rollDistance / 1.3f, playerProperties.unitMesh.forward, modified, 0);
    }

    void roll(float force, Vector3 direction, bool modified, float extraPower) {
        StartCoroutine(waitForRoll(force, direction, modified, extraPower));
    }

    public IEnumerator WaitForRelease(bool modified) {
        power = 0;
        shieldChargeUpAudio.Play();

        GameObject chargeup = Instantiate(chargeupEffect, shieldObject.transform.position + Vector3.up * 2, Quaternion.identity) as GameObject;
        chargeup.transform.SetParent(shieldObject.transform);

        do {
            playerProperties.attackProperties.canAttack = false;
            if (power < 2)
                power += 0.33f;
            else {
                if (chargeup != null)
                    Destroy(chargeup);
            }
            rollProperties.beginRoll = true;
            yield return new WaitForSeconds(0.1f);
        } while (Input.GetButton("Roll"));

        if (chargeup != null)
            Destroy(chargeup);
        roll(rollProperties.rollDistance, playerProperties.unitMesh.forward, modified, power);
        playerAnim.SetBool("IsCharging", true);
        StartCoroutine(FadeOutAudio(shieldChargeUpAudio, 0.2f));
        shieldChargeAudio.Play();
        power = 0;

    }

    IEnumerator FadeOutAudio(AudioSource audioSource, float time) {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0) {
            audioSource.volume -= Time.deltaTime / time * startVolume;
            yield return 0;
        }
        audioSource.Stop();
        audioSource.volume = startVolume;
    }


    private Vector3 FindRollTarget(float rollDistance, Vector3 direction, Vector3 startLocation, bool modified) {
        // modified = true  -> charge
        // modified = false -> normal roll
        RaycastHit hit;
        Vector3 targetPos = direction;
        /*
        // Look for ground each "checkDistance", if there is ground, set the targetPos to that location, otherwise, return the position we are at.
        */

        for (float i = 0f; i < rollDistance; i += checkDistance)
            if (Physics.Raycast(transform.position + direction * i, -Vector3.up, rollDistance, rollProperties.rollDetectionLayers) // If we can find ground
                && !Physics.Raycast(transform.position + direction * (i), direction, checkDistance, rollProperties.rollDetectionLayers)) {
                targetPos = transform.position + direction * i;

            } else {

                if (modified) {

                    if (Physics.Raycast(transform.position + direction * i, direction, out hit, checkDistance * 2, rollProperties.rollDetectionLayers)) { // If we are charging into a worldobject that canbe destroyed
                        if (hit.collider.gameObject.GetComponent<WorldObject>() && hit.collider.GetComponent<WorldObject>().destructable) { // Keep charging. Dont stop.
                            targetPos = transform.position + direction * i;
                            continue;
                        } else {
                            return targetPos - (direction);
                        }
                    } else {
                        return targetPos - (direction);
                    }
                } else { // if there is no ground
                    return targetPos;
                }

            }

        return targetPos - (direction);
    }

    private IEnumerator SpawnParticles() {
        Vector3 rot = playerProperties.unitMesh.rotation.eulerAngles;
        Destroy((GameObject)Instantiate(particlePrefab, transform.position + Vector3.up * 1.5f, Quaternion.Euler(new Vector3(90, rot.y + 90, 0))), 2f);
        yield return new WaitForSeconds(0.1f);

    }

    public IEnumerator waitForRoll(float force, Vector3 direction, bool modified, float extraRollpower) {

        if (modified && !abilityProperties.upgraded)
            modified = false;

        SoundManager.PlaySoundOneshot(rollDodgeSound);

        playerProperties.unitMesh.rotation = Quaternion.LookRotation(direction);
        float companionTempSpeed = playerProperties.companion.speed;
        float rollDistance = force;
        StartCoroutine(SpawnParticles());
        if (modified) {
            anim.SetTrigger("Charge");
            abilityProperties.modifiedCurrentCooldown = abilityProperties.modifiedMaxCooldown;

            isCharging = true;
            shieldProperties.canReflect = true;
            rollDistance *= 1 + extraRollpower;
            companionTempSpeed = playerProperties.companion.speed;
            playerProperties.companion.speed = int.MaxValue;
        } else {
            playerAnim.SetTrigger("Roll");
        }

        playerProperties.movementProperties.canRotate = false;
        rollProperties.canRoll = false;
        rollProperties.isRolling = true;

        Vector3 targetPos = direction;
        targetPos = FindRollTarget(rollDistance, direction, transform.position, modified);
        float counter = 0;
        int tries = 0;

        if (targetPos != direction)
            while (transform.position != targetPos && tries < maxChargeTries) { // Tries to charge until player is at target location or too many tries (saftety for if we get stuck)
                shieldProperties.shieldActive = true;
                if (GameController.isPaused) { // If the game is paused, just wait until we unpause the game, then continue the charge.
                    yield return new WaitForSeconds(0.01f);
                } else {
                    if (modified) { // If we are charging and not rolling: Deal damage.
                        dealDamageAtLocation(playerProperties.unitMesh.position + playerProperties.unitMesh.forward * checkDistance * 2 + playerProperties.unitMesh.up * 2, playerProperties.attackProperties.damage * extraRollpower / 2);
                    }

                    tries++;

                    counter += Time.deltaTime;

                    if (Physics.Raycast(transform.position + direction, -Vector3.up, rollDistance, rollProperties.rollDetectionLayers)
                        && !Physics.Raycast(transform.position + direction, direction, 0.1f, rollProperties.rollDetectionLayers))
                        transform.position = Vector3.MoveTowards(transform.position, targetPos, chargeSpeed * Time.deltaTime * rollProperties.rollSpeed.Evaluate(counter));
                    // rollProperties.rollSpeed is a curve that can be modified in the editor.
                    else
                        break;

                    yield return 0; // Wait one frame.
                }
            }

        yield return new WaitForSeconds(0.1f);
        playerProperties.movementProperties.canRotate = true;
        rollProperties.canRoll = true;
        rollProperties.isRolling = false;
        playerProperties.attackProperties.canAttack = true;
        rollProperties.beginRoll = false;

        if (modified) {
            shieldProperties.canReflect = false;
            isCharging = false;
            playerProperties.companion.speed = companionTempSpeed;
            playerAnim.SetBool("IsCharging", rollProperties.isRolling);
            anim.SetTrigger("Charge");
        } else {
            playerAnim.SetTrigger("Roll");
        }

        yield return null;
    }

    private void dealDamageAtLocation(Vector3 location, float damage) {

        if (GetComponent<EnemyAI>()) {

            Vector3 lookAtLocation = location;
            lookAtLocation.y = transform.position.y;
            GetComponent<UnitProperties>().unitMesh.LookAt(lookAtLocation);
        }

        FindAndDealDamage(location, damage);

    }

    protected virtual void FindAndDealDamage(Vector3 location, float damage) {
        Collider[] hits = Physics.OverlapSphere(location, playerProperties.attackProperties.aoe, playerProperties.attackProperties.hitLayers);
        foreach (Collider hit in hits) {
            UnitProperties up = hit.GetComponent<UnitProperties>();
            if (up && hit.gameObject != gameObject)
                up.TakeDamage(damage, up);
        }
    }
}

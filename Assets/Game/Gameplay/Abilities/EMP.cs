using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class EMP : Ability {
    private const float camShakeForce = 0.2f;
    private const float camShakeTime = 0.1f;
    public float AOE = 20;
    public float stunDuration = 1;
    private Player playerProperties;

    [SerializeField]
    private AudioClip EMPSlamSound;
    [SerializeField]
    private AudioClip EMPProjectileSound;

    public GameObject slamGroundEffect;

    public float shieldCost = 0.5f;

    void Awake() {
        playerProperties = GetComponent<Player>();

    }

    private void PlayEMPSound() {
        if (EMPSlamSound)
            SoundManager.PlaySoundOneshot(EMPSlamSound);
    }

    private IEnumerator FlickerLights() {
        Light[] l = FindObjectsOfType<Light>();

        List<Light> nearby = new List<Light>();
        foreach(Light light in l) {
            if (Vector3.Distance(transform.position, light.gameObject.transform.position) < 30) {
                nearby.Add(light);
                light.enabled = false;
            }
        }

        yield return new WaitForSeconds(0.5f);

        foreach (Light light in nearby) {
                light.enabled = true;            
        }
        yield return new WaitForSeconds(0.05f);

        foreach (Light light in nearby) {
            light.enabled = false;
        }
        yield return new WaitForSeconds(0.05f);

        foreach (Light light in nearby) {
            light.enabled = true;
        }
    }

    public override void UseAbility(bool modified) {

        if (abilityProperties.ModifiedCooldownReady && abilityProperties.upgraded && playerProperties.HasShield(shieldCost * playerProperties.shieldProperties.maxShieldHealth)) {

            playerProperties.TakeShieldDamage(shieldCost * playerProperties.shieldProperties.maxShieldHealth); // Removes a percentage of the players shield when used.
            Camera.main.GetComponent<CameraMovement>().ShakeCamera(camShakeForce, camShakeTime); // Shakes the camera.
            PlayEMPSound(); // Play the sound of the ability

            abilityProperties.modifiedCurrentCooldown = abilityProperties.modifiedMaxCooldown;
            Destroy(Instantiate(slamGroundEffect, transform.position + Vector3.up * 0.05f, Quaternion.identity), 4); // Spawn the ground effect and destroy it in 4 seconds.

            playerProperties.unitMesh.GetComponent<Animator>().SetTrigger("EMP"); // Play the EMP animation of the player.

            StartCoroutine(FlickerLights());

            Collider[] hits = Physics.OverlapSphere(transform.position, AOE, playerProperties.attackProperties.hitLayers); // Find all enemies in range.
            foreach (Collider hit in hits) {
                UnitProperties up = hit.gameObject.GetComponent<UnitProperties>();
                if (up) {
                    up.TakeDamage(0, playerProperties);

                    if (hit.GetComponent<WorldObject>() && hit.GetComponent<WorldObject>().destroyFromEMP) { // If the emp hit a shield, play its death animation and destroy it.
                        if (hit.GetComponent<Animator>()) {
                            hit.GetComponent<Animator>().SetTrigger("DestroyShield");
                            Destroy(hit.gameObject, 1f);
                        } else
                            up.TakeDamage(int.MaxValue, playerProperties); // Apply int.MaxValue damage to the object if it can take damage from emp and has no shield. This ensures that the object is killed.
                    }

                    up.AddStunDuration(stunDuration); 

                    if (hit.gameObject.GetComponent<Animator>() && hit.GetComponent<WorldObject>().canTriggerAnimation) { // If its a world object, like houses, where lights can be turned off.
                        hit.GetComponent<WorldObject>().canTriggerAnimation = false;
                        hit.gameObject.GetComponent<Animator>().SetTrigger("Trigger");
                    }
                }
            }
        }

    }


}

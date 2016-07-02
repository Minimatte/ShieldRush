using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class MovementProperties {
    public float movementSpeedBase = 5;
    public float movementSpeedMultiplier = 1;
    public bool canMove = true;
    public float rotationSpeed = 1;
    public bool canRotate = true;
    public bool slowed = false;
}

[Serializable]
public class HealthProperties {
    public float maxHealth, healthRegeneration;
    public float currentHealth;
    public bool invincible = false;
    public bool isAlive { get { return currentHealth > 0; } }
    public GameObject deathParticle;
    public bool stuckToUnit = true;
    public GameObject attachToGameObject;
    public List<AudioClip> deathSound;
    public List<AudioClip> getHitSound;
    public List<GameObject> getHitParticle;
}

[Serializable]
public class RollProperties {
    public AnimationCurve rollSpeed;
    public float rollDistance;
    internal bool isRolling;
    public bool canRoll = true;
    public LayerMask rollDetectionLayers;
    public bool beginRoll = false;
}

[Serializable]
public class AttackProperties {
    public float damage;
    public float range;

    public LayerMask hitLayers;
    public float attackCooldown;
    public float attackDuration = 2;
    public float aoe = 1;
    public bool canAttack = true;
    public float hitStun = 0.1f;

    public List<AudioClip> attackSound;
}

[Serializable]
public class AIProperties {
    public LayerMask detectLayers;
    public float detectionRange = 5;
    public float leash = 5;
    public bool active = true;
    public float stopRange = 1;

    public List<GameObject> deathDrops;
    public float dropChance = 100;
}

[Serializable]
public class ShieldProperties {
    public bool isAlive {
        get { return currentShieldHealth > 0; }
    }
    public bool isRegenerating = false;
    public bool canModify = true;
    public bool shieldActive = false;
    public bool canReflect = false;
    public float maxShieldHealth = 10;
    public float currentShieldHealth = 10;
    public float shieldRegeneration = 3;
    public float shieldRegenerationDelay = 3;
    public GameObject shieldHitParticle;
}

public class UnitProperties : MonoBehaviour {
    public Transform unitMesh;
    public HealthProperties healthProperty;
    public AttackProperties attackProperties;
    public MovementProperties movementProperties;

    public float stunnedTime = 0;

    void Awake() {
        healthProperty.currentHealth = healthProperty.maxHealth;
    }

    public virtual void GainHealth(float heal) {
        if (healthProperty.isAlive) {
            healthProperty.currentHealth += heal;
            healthProperty.currentHealth = Mathf.Clamp(healthProperty.currentHealth, 0, healthProperty.maxHealth);
        }
    }


    public virtual void TakeDamage(float damage, UnitProperties damageDealer) {
        if (!healthProperty.invincible) {
            if (healthProperty.isAlive) {
                healthProperty.currentHealth -= damage;
                healthProperty.currentHealth = Mathf.Clamp(healthProperty.currentHealth, 0, healthProperty.maxHealth);
            }

            if (healthProperty.getHitSound.Count > 0) {
                SoundManager.PlaySoundOneshot(healthProperty.getHitSound[UnityEngine.Random.Range(0, healthProperty.getHitSound.Count)]);
            }

            if (healthProperty.getHitParticle.Count > 0) {

                GameObject obj = Instantiate(healthProperty.getHitParticle[UnityEngine.Random.Range(0, healthProperty.getHitParticle.Count)], transform.position + Vector3.up * 1.7f, Quaternion.identity) as GameObject;
                obj.transform.SetParent(transform, true);
                Destroy(obj, 4f);

            }

            ApplyStun(damageDealer);
            CheckIfAlive();

        }
    }
    public virtual void AddStunDuration(float duration) {
        if (duration > stunnedTime)
            stunnedTime = duration;
    }

    protected virtual void ApplyStun(UnitProperties damageDealer) {
        if (damageDealer.attackProperties.hitStun > stunnedTime)
            stunnedTime = damageDealer.attackProperties.hitStun;
    }

    protected virtual void CheckIfAlive() {
        if (!healthProperty.isAlive) {

            if (healthProperty.deathParticle) {
                GameObject go = Instantiate(healthProperty.deathParticle, transform.position, Quaternion.Euler(Vector3.up)) as GameObject;
                if (healthProperty.stuckToUnit) {
                    if (healthProperty.attachToGameObject != null)
                        go.transform.SetParent(healthProperty.attachToGameObject.transform, true);
                    else
                        go.transform.SetParent(transform, true);
                }
                Destroy(go, 5f);
            }

            if (healthProperty.deathSound.Count > 0) {
                SoundManager.PlaySoundOneshot(healthProperty.deathSound[UnityEngine.Random.Range(0, healthProperty.deathSound.Count)]);
            }

            DestroyObject();
        }

    }

    protected virtual void DestroyObject() {

        Destroy(gameObject);
    }

    protected virtual void UpdateProperties() {

    }

    void Update() {
        UpdateProperties();
        if (stunnedTime > 0) {
            stunnedTime -= Time.deltaTime;

        } else {
            stunnedTime = 0;

        }
    }


}

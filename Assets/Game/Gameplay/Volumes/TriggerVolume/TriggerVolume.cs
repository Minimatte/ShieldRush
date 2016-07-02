using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public enum Abilities {
    Bash,
    Charge,
    Emp
}

public enum ActivationType {
    Enter,
    Interact,
    Empty,
    Trigger,
    Inside
}

[RequireComponent(typeof(Collider))]
public class TriggerVolume : Interactable {

    #region Fields
    public LayerMask insideCheck;
    [Header("Trigger")]
    [Tooltip("Empty require trigger once")]
    public ActivationType activationType;
    public TriggerVolume otherTrigger;
    public float activationDelay = 0;
    public bool triggerOnce = true;
    private bool hasTriggered = false;

    private Collider[] objectsInArea;
    public LayerMask checkMask;

    [Header("Camera Options")]
    public bool useCameraBlend = false;
    public Transform cameraTarget;
    public float cameraDelay = 0;
    public float duration = 3;
    public float playerDisableDelay = 0;
    public bool disablePlayer = true;
    public float cameraSize = 12;
    public float cameraSpeed = 10;

    [Header("Camera Shake")]
    public float cameraShakeDelay = 0;
    public float cameraShakeTime = 0;
    public float cameraShakeForce = 0;


    [Header("Animation Options")]
    public bool useAnimation = false;
    public Animator animator;
    public string trigger = "Trigger";
    public float animationDelay = 0;

    [Header("Sound Options")]
    public bool playSound = false;
    public AudioClip soundClip;
    public float soundDelay = 0;
    public bool specificLocation = false;
    public Transform soundLocation;

    [Header("Particle Options")]
    public bool useParticles = false;
    public GameObject particlePrefab;
    public float particleDelay = 0;
    public Transform particleLocation;
    public float particleLifetime = 4;

    [Header("Enemy Spawner Options")]
    public bool triggerEnemySpawner = false;
    public EnemySpawner[] enemySpawner;
    public float enemyDelay = 0;

    [Header("Enable/Disable Objects")]
    public bool enableDisableObjects = false;
    public float ObjectsDelay = 0;
    public List<GameObject> objectsToEnable;
    public List<GameObject> objectsToDisable;

    [Header("Give Player Ability")]
    public bool givePlayerAbility = false;
    public float abilityDelay = 0;
    public Abilities abilityToGive;

    [Header("Apply Force")]
    public bool applyForce = false;
    public float forceDelay = 0;
    public float forceRadius = 5;
    public float forcePower = 5000;
    public ForceMode powerForceMode;

    [Header("Trigger Animations Area")]
    public bool triggerAnimations = false;
    public float animationDelays = 0;
    public float animationRadius = 5;
    public string animationTriggerName = "Trigger";
    public LayerMask animationMask;

    [Header("DealDamage")]
    public bool dealDamage = false;
    public float damageDelay = 0;
    public float damageRadius = 5;
    public float damageAmount = 1;
    public LayerMask damageLayer;


    [Header("TriggerBehaviourAnimation")]
    public bool triggerBehaviour = false;
    public float behaviourDelay = 0;
    public AIBehaviourAnimation behaviour;

    [Header("ActivateBehaviour(s)")]
    public bool ActivateBehaviour = false;
    public float behaviourActivateDelay = 0;
    public List<AIBehaviour> behaviourToActivate;

    [Header("TRAIN!")]
    public bool activateTrain = false;
    public float trainDelay = 0;
    public Train train;

    #endregion

    float tempCamSize;
    float tempCamSpeed;

    private bool takenCamSize = false;
    void Start() {
        Camera cam = Camera.main;
        if (cam.GetComponent<CameraMovement>()) {
            takenCamSize = true;
            tempCamSize = cam.GetComponent<CameraMovement>().camSize;
            tempCamSpeed = cam.GetComponent<CameraMovement>().playerVelocity;
        }
    }

    void Awake() {
        if (useAnimation && animator == null)
            throw new Exception("Assign an animator for " + name);
    }

    void Update() {
        Camera cam = Camera.main;
        if (cam.GetComponent<CameraMovement>() && !takenCamSize) {
            takenCamSize = true;
            tempCamSize = cam.GetComponent<CameraMovement>().camSize;
            tempCamSpeed = cam.GetComponent<CameraMovement>().playerVelocity;
        }
        objectsInArea = Physics.OverlapBox(transform.position, GetComponent<Collider>().bounds.extents, Quaternion.LookRotation(Vector3.forward, Vector3.up), checkMask);

        if (objectsInArea.Length == 0 && activationType == ActivationType.Empty) {
            if (triggerOnce) {
                if (!hasTriggered) {
                    Trigger();
                    hasTriggered = true;
                }
            }
        }
    }

    public void Trigger() {
        if (triggerOnce) {
            if (!hasTriggered) {
                StartCoroutine(ActivationDelayThis(activationDelay));
                hasTriggered = true;
            }
        } else
            StartCoroutine(ActivationDelayThis(activationDelay));

    }

    private IEnumerator ActivationDelayThis(float delay) {
        yield return new WaitForSeconds(delay);
        if (otherTrigger != null && otherTrigger.activationType == ActivationType.Trigger)
            StartCoroutine(ActivationDelay(activationDelay));

        if (activateTrain)
            StartCoroutine(ActivateTrain(trainDelay));
        if (ActivateBehaviour)
            StartCoroutine(ActivateBehaviours(behaviourActivateDelay));
        if (triggerBehaviour)
            StartCoroutine(TriggerBehaviour(behaviourDelay));
        if (dealDamage)
            StartCoroutine(DealDamage(damageDelay));
        if (triggerAnimations)
            StartCoroutine(TriggerAnimations(animationDelays));
        if (applyForce)
            StartCoroutine(ApplyForceToObjects(forceDelay));
        if (givePlayerAbility)
            StartCoroutine(GiveAbility(abilityDelay));
        if (cameraShakeForce > 0 && cameraShakeTime > 0)
            StartCoroutine(ShakeCameraDelay(cameraShakeDelay));
        if (useCameraBlend) {
            //tempCamSize = Camera.main.GetComponent<CameraMovement>().camSize;
            StartCoroutine(MoveCamera(cameraDelay, duration, cameraTarget.gameObject, disablePlayer, cameraSize, cameraSpeed));
        }
        if (useAnimation)
            StartCoroutine(PlayAnimation(animationDelay, trigger));
        if (playSound)
            StartCoroutine(PlaySound(soundDelay));
        if (useParticles)
            StartCoroutine(SpawnParticles(particleDelay));
        if (triggerEnemySpawner)
            StartCoroutine(SpawnEnemies(enemyDelay));
        if (enableDisableObjects)
            StartCoroutine(EnableObjects(ObjectsDelay));
    }

    private IEnumerator ActivateTrain(float delay) {
        yield return new WaitForSeconds(delay);
        train.enabled = true;
    }

    private IEnumerator ActivateBehaviours(float delay) {
        yield return new WaitForSeconds(delay);
        foreach (AIBehaviour b in behaviourToActivate)
            b.enabled = true;
    }

    private IEnumerator TriggerBehaviour(float delay) {
        yield return new WaitForSeconds(delay);
        behaviour.TriggerEvent();
    }

    private IEnumerator DealDamage(float delay) {
        yield return new WaitForSeconds(delay);
        Collider[] hits = Physics.OverlapSphere(transform.position, damageRadius, damageLayer);
        foreach (Collider hit in hits) {
            if (hit.gameObject.GetComponent<UnitProperties>()) {
                hit.gameObject.GetComponent<UnitProperties>().TakeDamage(damageAmount, hit.gameObject.GetComponent<UnitProperties>());
            }
        }
    }

    private IEnumerator TriggerAnimations(float delay) {
        yield return new WaitForSeconds(delay);
        Collider[] hits = Physics.OverlapSphere(transform.position, animationRadius, animationMask);
        foreach (Collider hit in hits) {
            if (hit.gameObject.GetComponent<Animator>()) {
                foreach (var currParam in hit.gameObject.GetComponent<Animator>().parameters) {
                    if (currParam.name == animationTriggerName) {
                        hit.gameObject.GetComponent<Animator>().SetTrigger(animationTriggerName);
                    }
                }
            }
        }
    }

    private IEnumerator ApplyForceToObjects(float delay) {
        yield return new WaitForSeconds(delay);
        Collider[] hits = Physics.OverlapSphere(transform.position, forceRadius, checkMask);
        foreach (Collider hit in hits) {
            if (hit.gameObject.GetComponent<Rigidbody>()) {
                hit.gameObject.GetComponent<Rigidbody>().AddExplosionForce(forcePower, transform.position, forceRadius, 2, powerForceMode);
            }
        }
    }

    private IEnumerator GiveAbility(float delay) {
        yield return new WaitForSeconds(delay);
        GameObject go = Instantiate(Resources.Load("VFX/P_NewAbility"), GameController.Player.transform.position + Vector3.up * 2.5f, Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
        go.transform.SetParent(GameController.Player.transform, true);
        Destroy(go, 2);
        AbilityHandler handler = GameController.Player.GetComponent<AbilityHandler>();
        switch (abilityToGive) {
            case Abilities.Charge:
                UIManager.LearnCharge();
                handler.AddAbility(typeof(ShieldCharge));
                GameObject.Find("PlayerUI").GetComponent<Animator>().SetTrigger("NewAbility");
                break;
            case Abilities.Emp:
                UIManager.LearnEMP();
                handler.AddAbility(typeof(EMP));
                GameObject.Find("PlayerUI").GetComponent<Animator>().SetTrigger("NewAbility");
                break;
            case Abilities.Bash:
                UIManager.LearnReflect();
                handler.AddAbility(typeof(ShieldBash));
                GameObject.Find("PlayerUI").GetComponent<Animator>().SetTrigger("FirstAbility");
                break;
        }
    }

    private IEnumerator ActivationDelay(float delay) {
        yield return new WaitForSeconds(delay);
        otherTrigger.Trigger();
    }

    private IEnumerator EnableObjects(float delay) {
        yield return new WaitForSeconds(delay);
        foreach (GameObject go in objectsToEnable) {
            go.SetActive(true);
        }
        foreach (GameObject go in objectsToDisable) {
            go.SetActive(false);
        }
    }

    private IEnumerator ShakeCameraDelay(float delay) {
        yield return new WaitForSeconds(delay);
        Camera.main.GetComponent<CameraMovement>().ShakeCamera(cameraShakeTime, cameraShakeForce);
    }

    private IEnumerator SpawnEnemies(float delay) {
        yield return new WaitForSeconds(delay);
        if (enemySpawner != null) {
            foreach (EnemySpawner e in enemySpawner) {
                e.SetUp();
            }
        }
    }

    private IEnumerator SpawnParticles(float delay) {
        yield return new WaitForSeconds(delay);
        if (particlePrefab != null)
            Destroy(Instantiate(particlePrefab, particleLocation.position, Quaternion.identity), particleLifetime);
    }

    private IEnumerator PlaySound(float delay) {
        yield return new WaitForSeconds(delay);
        if (specificLocation)
            AudioSource.PlayClipAtPoint(soundClip, soundLocation.position);
        else
            AudioSource.PlayClipAtPoint(soundClip, transform.position);
    }

    private IEnumerator PlayAnimation(float delay, string trigger) {
        yield return new WaitForSeconds(delay);

        animator.SetTrigger(trigger);
    }

    private IEnumerator MoveCamera(float delay, float duration, GameObject target, bool disablePlayer, float camSize, float cameraSpeed) {
        yield return new WaitForSeconds(delay);
        if (GameController.Player != null) {
            if (disablePlayer) {
                Player p = GameController.Player.GetComponent<Player>();
                p.healthProperty.invincible = true;
                p.movementProperties.canMove = false;
            }
        }

        yield return new WaitForSeconds(playerDisableDelay);
        CameraMovement CM = Camera.main.GetComponent<CameraMovement>();


        CM.camSize = camSize;
        CM.playerVelocity = cameraSpeed;

        CM.player = target;
        yield return new WaitForSeconds(duration);
        if (activationType != ActivationType.Inside) {
            resetCamera(tempCamSpeed, tempCamSize);
        } else { // check if player is still in the box

            float amount = 0;
            Collider[] lookForPlayer;
            do {
                lookForPlayer = Physics.OverlapBox(transform.position, GetComponent<Collider>().bounds.extents, Quaternion.identity, insideCheck);
                amount = lookForPlayer.Length;
                yield return new WaitForSeconds(0.1f);

            } while (amount > 0);
            resetCamera(tempCamSpeed, tempCamSize);
        }
    }

    private void resetCamera(float cSpeed, float cSize) {
        CameraMovement CM = Camera.main.GetComponent<CameraMovement>();
        if (GameController.Player != null) {
            CM.player = GameController.Player;
            if (disablePlayer) {
                Player p = GameController.Player.GetComponent<Player>();
                p.movementProperties.canMove = true;
                p.healthProperty.invincible = false;

                p.movementProperties.movementSpeedMultiplier = 1;
            }
        } else {
            CM.player = gameObject;
        }
        CM.playerVelocity = cSpeed;
        CM.camSize = cSize;
        CM.distance = cSize;
    }

    public override void Interact() {
        if (activationType == ActivationType.Interact) {
            Trigger();
        }
    }

    public void OnTriggerStay(Collider other) {
        if (!other.gameObject.CompareTag("Projectile"))
            if (checkMask == (checkMask | (1 << other.gameObject.layer))) {
                if (activationType == ActivationType.Inside) {
                    Trigger();
                }
            }
    }

    void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("Projectile"))
            if (activationType == ActivationType.Enter && checkMask == (checkMask | (1 << other.gameObject.layer))) {
                Trigger();
            }
    }

    void OnDrawGizmos() {
        if (applyForce)
            Gizmos.DrawWireSphere(transform.position, forceRadius);
        if (triggerAnimations) {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, animationRadius);
        }

        if (dealDamage) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, damageRadius);
        }
    }
}

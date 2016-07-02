using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerAttack : MonoBehaviour {

    [Tooltip("Leave empty if you want default")]
    public string attackInput;
    [Tooltip("Leave empty if you want default")]
    public string shieldInput;
    [Tooltip("Leave empty if you want default")]
    public string rollInput;
    [Tooltip("Leave empty if you want default")]
    public string empInput;


    private float combatTime = 0;

    public bool shieldActive {
        get { return (Input.GetButton(shieldInput) || Input.GetAxisRaw("Shield") < 0) || p.rollProperties.beginRoll || GetComponent<ShieldCharge>().isCharging || ShieldBash.isCharging; }
    }
    private Player p;
    public GameObject shieldObject;
    private ShieldBash shieldBash;
    private ShieldCharge shieldCharge;
    private EMP emp;

    [SerializeField]
    private AudioClip shieldActivateAudio;
    [SerializeField]
    private AudioClip shieldDeathAudio;

    public bool hasPlayed = false;

    public GameObject companionTurnIntoShieldEffect;

    void Start() {
        p = GetComponent<Player>();
        if (GetComponent<ShieldBash>())
            shieldBash = GetComponent<ShieldBash>();
        if (GetComponent<ShieldCharge>())
            shieldCharge = GetComponent<ShieldCharge>();
        if (GetComponent<EMP>())
            emp = GetComponent<EMP>();

        if (attackInput == "")
            attackInput = "MeleeAttack";
        if (shieldInput == "")
            shieldInput = "Shield";
        if (rollInput == "")
            rollInput = "Roll";
        if (empInput == "")
            empInput = "EMP";
    }

    private bool effectActivated = false;

    void Update() {
        if (!PlayerMovement.PlayerActive)
            return;


        p = GetComponent<Player>();

        if (p != null) {
            if (p.shieldProperties.currentShieldHealth <= 0 && !hasPlayed) {
                SoundManager.PlaySoundOneshot(shieldDeathAudio);
                hasPlayed = true;
            } else if (p.shieldProperties.currentShieldHealth > 0 && hasPlayed) {
                hasPlayed = false;
            }
        }

        if (GameController.isPaused)
            return;

        if (shieldBash == null && GetComponent<ShieldBash>()) {
            shieldBash = GetComponent<ShieldBash>();
        }

        if (shieldCharge == null && GetComponent<ShieldCharge>()) {
            shieldCharge = GetComponent<ShieldCharge>();
        }

        if (emp == null && GetComponent<EMP>()) {
            emp = GetComponent<EMP>();
        }

        if (combatTime > 0) {
            combatTime -= Time.deltaTime;
            combatTime = Mathf.Clamp(combatTime, 0, 10);
        }

        p.unitMesh.GetComponent<Animator>().SetBool("InCombat", combatTime > 0);
        p.unitMesh.GetComponent<Animator>().SetBool("IsShielding", shieldActive);
        if (GameObject.Find("ScreenEffects"))
            ScreenEffects.ShieldOnEffect(shieldActive);

        p.attackProperties.canAttack = !shieldActive;
        p.movementProperties.canRotate = shieldActive && !p.rollProperties.isRolling;
        if (!p.rollProperties.isRolling)
            shieldObject.SetActive(shieldActive && p.shieldProperties.isAlive);



        if (GetComponent<PlayerMovement>().canMove) {

            p.shieldProperties.shieldActive = shieldActive;


            if (shieldActive && p.shieldProperties.isAlive || p.movementProperties.slowed) {
                p.movementProperties.movementSpeedMultiplier = 0.3f;
                combatTime += Time.deltaTime * 2;
            } else {
                p.movementProperties.movementSpeedMultiplier = 1;

            }

            if (Input.GetAxisRaw("Shield") == -1 && !effectActivated) {
                CompanionEffect();
                effectActivated = true;
            }
            if (Input.GetAxisRaw("Shield") >= 0 && effectActivated) {
                effectActivated = false;
                CompanionEffect();
            }


            if (Input.GetButtonDown(shieldInput) && p.shieldProperties.isAlive) {
                SoundManager.PlaySoundOneshot(shieldActivateAudio);
            }

            p.companion.GetComponent<Animator>().SetBool("Shield", shieldActive);

            if (Input.GetButtonUp(shieldInput) && !shieldActive) {
                shieldObject.GetComponent<Shield>().ResetSize();

                //p.companion.GetComponent<Animator>().SetTrigger("Shield");
            }

            if (shieldActive && p.shieldProperties.isAlive)
                GetComponent<PlayerRotation>().LookAtMouse();

            if (GetComponent<CharacterController>().isGrounded)
                if (shieldCharge != null && Input.GetButtonDown(rollInput) /*&&  rollProperties.canRoll && dxy != Vector3.zero && canMove*/) {
                    shieldCharge.UseAbility(shieldActive);
                    combatTime += 1 + p.attackProperties.attackDuration * (Time.deltaTime * 10);
                }

            if (emp != null && !p.rollProperties.isRolling && Input.GetButtonDown(empInput))
                emp.UseAbility(shieldActive);

            if (GetComponent<CharacterController>().isGrounded && !p.rollProperties.beginRoll)
                if (shieldBash != null && !p.rollProperties.isRolling && Input.GetButtonDown(attackInput)) {

                    CompanionEffect();


                    shieldBash.UseAbility(shieldActive);
                    combatTime += 1 + p.attackProperties.attackDuration * (Time.deltaTime * 10);

                }
        }
    }


    private void CompanionEffect() {
        Destroy(Instantiate(companionTurnIntoShieldEffect, p.companion.transform.position, Quaternion.identity), 1f);
    }




    void ShieldCost() {
        if (shieldActive) {
            p.TakeShieldDamage(Time.deltaTime);
        }
    }
}

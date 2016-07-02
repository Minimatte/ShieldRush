using UnityEngine;
using System.Collections;
using System;

public class ShieldBash : Ability {

    public static bool isCharging = false;
    private Player playerProperties;
    private AttackProperties attackProperties;
    private int currentCombo = 0;
    public Animator anim;

    public GameObject testPrefab;

    [HideInInspector]
    public bool canUse = true;

    public int combo = 3;

    public float modifiedCost = 0;
    public float power = 0;
    private IEnumerator coroutine;

    void Start() {
        if (GetComponent<Player>()) {
            playerProperties = GetComponent<Player>();
            attackProperties = playerProperties.attackProperties;
        }
    }

    public override void UseAbility(bool modified) {
        if (abilityProperties.hasLearnt) {
            if (modified && !playerProperties.shieldProperties.isAlive)
                return;

            if (!modified && !abilityProperties.UnmodifiedCooldownReady)
                return;

            if (modified && !abilityProperties.ModifiedCooldownReady) {
                return;
            }

            abilityProperties.modified = modified;
            if (canUse) {
                if (modified && abilityProperties.upgraded)
                    StartCoroutine(WaitForRelease(modified));
                else
                    StartCoroutine(WaitForAbility(modified, 1));
            }
        }
    }

    private IEnumerator ToggleReflect() {
        Player p = GetComponent<Player>();
        p.shieldProperties.canReflect = true;
        yield return new WaitForSeconds(p.attackProperties.attackDuration * 3f);
        p.shieldProperties.canReflect = false;
    }

    public IEnumerator WaitForRelease(bool modified) {
        power = 0;
        isCharging = true;

        playerProperties.ShieldAnimator.SetBool("Bash", true);
        while (Input.GetButton("MeleeAttack")) {
            playerProperties.attackProperties.canAttack = false;
            if (power < 2)
                power += 0.5f;
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(ToggleReflect());
        anim.SetTrigger("Reflect");
        playerProperties.ShieldAnimator.SetBool("Bash", false);
        StartCoroutine(WaitForAbility(modified, power));
        power = 0;
        yield return new WaitForSeconds(0.2f);
        isCharging = false;
    }

    IEnumerator CheckForCombo() {
        yield return new WaitForSeconds(attackProperties.attackDuration);
        currentCombo = 0;
        playerProperties.movementProperties.slowed = false;
        playerProperties.companion.side = 1;
    }

    IEnumerator WaitForAbility(bool modified, float power) {
        if (!modified)
            currentCombo++;

        bool waitAfter = true;
        if (currentCombo <= combo) {

            if (!Options.UseController)
                GetComponent<PlayerRotation>().LookAtMouse();
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = CheckForCombo();
            StartCoroutine(coroutine);

            playerProperties.movementProperties.slowed = true;

            if (modified && abilityProperties.upgraded) {
                UseAbilityModified();
                abilityProperties.modifiedCurrentCooldown = abilityProperties.modifiedMaxCooldown;
            } else if (!playerProperties.shieldProperties.shieldActive) {
                UseAbilityUnModified();

                MoveCompanion();
                anim.SetTrigger("Attack");
                abilityProperties.unmodifiedCurrentCooldown = abilityProperties.unmodifiedMaxCooldown;
                Vector3 rot = playerProperties.transform.eulerAngles + new Vector3(0, 0, 0);

                if (attackProperties.attackSound.Count > 0) {
                    SoundManager.PlaySoundOneshot(attackProperties.attackSound[UnityEngine.Random.Range(0, attackProperties.attackSound.Count)]);
                }


                Destroy(Instantiate(testPrefab, playerProperties.companion.transform.position, Quaternion.Euler(rot)), 3);

            } else {
                waitAfter = false;
            }

            if (waitAfter) {

                if (currentCombo == combo) {
                    StopCoroutine(coroutine);
                    yield return new WaitForSeconds(attackProperties.attackDuration * 1.5f);
                    currentCombo = 0;
                } else {
                    yield return new WaitForSeconds(attackProperties.attackDuration);
                }
            }
            playerProperties.movementProperties.slowed = false;
        }

    }

    void MoveCompanion() {
        Companion c = playerProperties.companion;
        float side = 0;

        bool fwd = false;

        switch (currentCombo) {
            case 1:
                side = -1; // left
                break;
            case 2:
                side = 1; // right
                break;
            case 3:
                side = 1; // right
                fwd = true; // forward
                break;

        }

        c.side = side;
        if (fwd)
            c.transform.position = playerProperties.unitMesh.position + playerProperties.unitMesh.forward * side * 2 + playerProperties.unitMesh.up * 2;
        else
            c.transform.position = playerProperties.unitMesh.position + playerProperties.unitMesh.right * side * 2 + playerProperties.unitMesh.up * 2;
        c.GetComponent<Animator>().SetTrigger("Attack");
    }


    void UseAbilityModified() {
        DealDamageAtLocation(playerProperties.unitMesh.position + playerProperties.unitMesh.transform.up + playerProperties.unitMesh.transform.forward * attackProperties.range * 2, attackProperties.damage, playerProperties.shieldProperties.shieldActive);

    }

    void UseAbilityUnModified() {
        DealDamageAtLocation(playerProperties.unitMesh.position + playerProperties.unitMesh.transform.up + playerProperties.unitMesh.transform.forward * attackProperties.range, attackProperties.damage, playerProperties.shieldProperties.shieldActive);
    }

    private void DealDamageAtLocation(Vector3 location, float damage, bool modified) {

        if (GetComponent<EnemyAI>()) {

            Vector3 lookAtLocation = location;
            lookAtLocation.y = transform.position.y;
            GetComponent<UnitProperties>().unitMesh.LookAt(lookAtLocation);
        }

        if (modified)
            FindAndDealDamage(location, damage);
        else
            FindTarget(location, damage);

    }

    private void FindTarget(Vector3 location, float damage) {
        Collider[] hits = Physics.OverlapSphere(location, attackProperties.aoe, attackProperties.hitLayers);

        Collider target = null;

        foreach (Collider hit in hits) { // find nearest target
            UnitProperties up = hit.GetComponent<UnitProperties>();
            if (up && hit.gameObject != gameObject) {
                if (target == null)
                    target = hit;
                else {
                    if (Vector3.Distance(target.transform.position, transform.position) > Vector3.Distance(hit.transform.position, transform.position)) {
                        target = hit;
                    }
                }
            }
        }
        if (target != null) {
            playerProperties.unitMesh.LookAt(new Vector3(target.transform.position.x, playerProperties.unitMesh.position.y, target.transform.position.z));
            target.GetComponent<UnitProperties>().TakeDamage(damage, playerProperties);
        }
    }

    protected virtual void FindAndDealDamage(Vector3 location, float damage) {
        Collider[] hits = Physics.OverlapSphere(location, attackProperties.aoe * 2, attackProperties.hitLayers);
        foreach (Collider hit in hits) {
            UnitProperties up = hit.GetComponent<UnitProperties>();
            if (up && hit.gameObject != gameObject) {
                up.TakeDamage(damage, playerProperties);

                if (playerProperties.shieldProperties.isAlive && playerProperties.shieldProperties.shieldActive) {
                    hit.GetComponent<Rigidbody>().AddForce(Vector3.up * 50000, ForceMode.Impulse);
                    hit.GetComponent<Rigidbody>().AddForce((hit.transform.position - GameController.Player.transform.position) * 35000 * power, ForceMode.Impulse);
                }


            }
        }
    }

    void OnDrawGizmos() {
        if (Application.isPlaying)
            if (!playerProperties.shieldProperties.shieldActive) {
                Gizmos.DrawWireSphere(playerProperties.unitMesh.position + playerProperties.unitMesh.transform.up + playerProperties.unitMesh.transform.forward * attackProperties.range, attackProperties.aoe);
            } else
                Gizmos.DrawWireSphere(playerProperties.unitMesh.position + playerProperties.unitMesh.transform.up + playerProperties.unitMesh.transform.forward * attackProperties.range * 2, attackProperties.aoe * 2);
    }


}

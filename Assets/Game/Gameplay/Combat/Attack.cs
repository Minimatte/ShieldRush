using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(UnitProperties))]
public abstract class Attack : MonoBehaviour {
    protected Transform mesh;
    protected AttackProperties attackProperties;

    internal float currentCooldown = 0;
    internal bool canAttack { get { return currentCooldown <= 0; } }

    void Awake() {
        UnitProperties up = GetComponent<UnitProperties>();
        attackProperties = up.attackProperties;
        if (up.unitMesh != null)
            mesh = up.unitMesh;
        else
            throw new Exception("Assign a mesh to the unit properties i.e player");
    }

    void Update() {
        if (currentCooldown > 0)
            currentCooldown -= Time.deltaTime;
        else
            currentCooldown = 0;

    }

    protected virtual void FindAndDealDamage(Vector3 location, float damage) {
        float aoe = attackProperties.aoe;

        Collider[] hits = Physics.OverlapSphere(location, aoe, attackProperties.hitLayers);
        foreach (Collider hit in hits) {
            UnitProperties up = hit.GetComponent<UnitProperties>();
            if (hit.GetComponent<Shield>()) {
                hit.GetComponent<Shield>().player.TakeShieldDamage(damage);
                hit.GetComponent<Animator>().SetTrigger("TakeDamage");
                break;
            } else if (up && hit.gameObject != gameObject) {
                up.TakeDamage(damage, GetComponent<UnitProperties>());
                break;
            }
        }
    }
#if UNITY_EDITOR
    void OnDrawGizmos() {
        if (Application.isPlaying && GenericDebug.gizmosActive)
            Gizmos.DrawWireCube(transform.position + mesh.forward * attackProperties.range, new Vector3(attackProperties.aoe, attackProperties.aoe, attackProperties.aoe));
    }
#endif

    public abstract void UseAttack(Vector3 location);
}

using System;
using UnityEngine;

public class MeleeAttack : Attack {

    public override void UseAttack(Vector3 location) { // if we want to target a specific location, mainly used for the ai
        Animator anim = GetComponent<UnitProperties>().unitMesh.GetComponent<Animator>();
        if (anim) {
            anim.SetInteger("AttackVariation", UnityEngine.Random.Range(0, 3));
            anim.SetTrigger("Attack");
        }
        if (location != null)
            findLoc(location, attackProperties.damage);
    }

    private void findLoc(Vector3 direction, float damage) {

        Vector3 lookAtLocation = direction - transform.position;
        lookAtLocation.Normalize();
        transform.LookAt(transform.position + lookAtLocation);

        currentCooldown = attackProperties.attackCooldown;
        FindAndDealDamage(transform.position + lookAtLocation * attackProperties.range, damage);

    }
}

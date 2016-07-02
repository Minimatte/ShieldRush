using UnityEngine;
using System.Collections;
using System;

public class RangeAttack : Attack {

    public GameObject projectilePrefab;

    public Transform attackPoint;
    public float spawnDelay = 0;

    public override void UseAttack(Vector3 location) {
        Animator anim = GetComponent<UnitProperties>().unitMesh.GetComponent<Animator>();
        if (anim) {
            anim.SetTrigger("Attack");
        }
        StartCoroutine(WaitForSpawnDelay(location));
    }

    protected virtual IEnumerator WaitForSpawnDelay(Vector3 location) {
        yield return new WaitForSeconds(spawnDelay);
        GameObject projectile = null;
        if (GetComponent<UnitProperties>().healthProperty.isAlive) {

            if (attackPoint == null) {

                projectile = (GameObject)Instantiate(projectilePrefab, transform.position, transform.rotation);
                projectile.GetComponent<Projectile>().Initialize((location - transform.position).normalized, attackProperties, gameObject);

            } else {
                projectile = (GameObject)Instantiate(projectilePrefab, attackPoint.position, transform.rotation);
                Vector3 target = (GameController.Player.transform.position - attackPoint.transform.position) + Vector3.up;
                projectile.GetComponent<Projectile>().Initialize(target.normalized, attackProperties, gameObject);
                projectile.GetComponent<Projectile>().owner = gameObject;
            }

            projectile.gameObject.layer = gameObject.layer;
        }
    }

}

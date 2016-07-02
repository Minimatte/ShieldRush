using UnityEngine;
using System.Collections;

public class RangeAttackBurst : RangeAttack {

    public int projectilesPerAttack;


    protected override IEnumerator WaitForSpawnDelay(Vector3 location) {
        yield return new WaitForSeconds(spawnDelay);
        for (int i = 0; i < projectilesPerAttack; i++) {
            GameObject projectile = null;
            if (GetComponent<UnitProperties>().healthProperty.isAlive) {

                if (attackPoint == null)
                    projectile = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.LookRotation(transform.forward, Vector3.up));
                else
                    projectile = (GameObject)Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);

                projectile.GetComponent<Projectile>().Initialize((location - transform.position).normalized, attackProperties, gameObject);
                projectile.gameObject.layer = gameObject.layer;
                yield return new WaitForSeconds(attackProperties.attackDuration / projectilesPerAttack);
            }
        }
    }
}

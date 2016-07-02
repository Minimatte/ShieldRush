using UnityEngine;
using System.Collections;

public class EMPProjectile : Projectile {
    public LayerMask HitLayers;
    public float AOE = 2;
    public GameObject imapctEffectParticlePrefab;
    void Awake() {
        Invoke("DestroyProjectile", lifespan);
    }

    void OnCollisionEnter(Collision collision) {

        if ((attackProperties.hitLayers.value & 1 << collision.gameObject.layer) != 0) {
            DestroyProjectile();
        }
    }

    void DestroyProjectile() {
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<ParticleSystem>().Stop();
        Destroy(Instantiate(imapctEffectParticlePrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity), 1f);

        RaycastHit[] hits = Physics.SphereCastAll(transform.position, AOE, Vector3.up, attackProperties.hitLayers);
        foreach (RaycastHit hit in hits) {

            if (hit.collider.GetComponent<EMPTrigger>())
                hit.collider.GetComponent<EMPTrigger>().Trigger();

            UnitProperties up = hit.collider.gameObject.GetComponent<UnitProperties>();
            if (up)
                up.stunnedTime = (owner.GetComponent<EMP>().stunDuration);

            if (hit.collider.gameObject.GetComponent<Animator>() && hit.collider.GetComponent<WorldObject>() && hit.collider.GetComponent<WorldObject>().canTriggerAnimation) {
                hit.collider.gameObject.GetComponent<Animator>().SetTrigger("Trigger");
                hit.collider.gameObject.GetComponent<Animator>().SetTrigger("ResetTrigger");
            }
        }
        Destroy(gameObject, 1);
    }
}

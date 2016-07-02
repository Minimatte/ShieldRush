using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

    public AttackProperties attackProperties;
    public float speed = 10;
    public float lifespan = 3;

    public GameObject owner;
    private bool hasBounced = false;

    [SerializeField]
    AudioClip throwSound;
    [SerializeField]
    AudioClip destroySound;
    [SerializeField]
    AudioClip reflectSound;

    public void ShootInDirection(Vector3 force) {
        GetComponent<Rigidbody>().velocity = force;
    }

    public void Initialize(Vector3 direction, AttackProperties attackProperties, GameObject owner) {
        Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Projectile"));

        ShootInDirection(direction.normalized * speed);
        this.attackProperties = attackProperties;
        this.owner = owner;
        GetComponent<Rigidbody>().freezeRotation = true;

        SoundManager.PlaySoundOneshot(throwSound);

        Invoke("DestroyThis", lifespan);
    }

    private Vector3 oldVelocity;
    void OnCollisionEnter(Collision collision) {

        if (collision.collider.CompareTag("Shield")) {
            Player p = collision.collider.transform.root.GetComponent<Player>();
            attackProperties = collision.collider.transform.root.GetComponent<UnitProperties>().attackProperties;
            p.TakeShieldDamage(attackProperties.damage, collision.contacts[0]);
            if (!hasBounced) {
                SoundManager.PlaySoundOneshot(destroySound);
            }

            if (p.shieldProperties.canReflect) {
                if (!hasBounced) {

                    gameObject.layer = collision.collider.gameObject.layer;

                    Vector3 reflectedVelocity = owner.transform.position - gameObject.transform.position;
                    reflectedVelocity.y = 1;
                    GetComponent<Rigidbody>().velocity = reflectedVelocity.normalized * speed;

                    //Quaternion rotation = Quaternion.FromToRotation(oldVelocity, reflectedVelocity);
                    //transform.rotation = rotation * transform.rotation;
                    hasBounced = true;
                    SoundManager.PlaySoundOneshot(reflectSound);
                    print(reflectedVelocity.normalized);
                }

            } else if (p.shieldProperties.shieldActive) {
                DestroyThis();
            } else {
                CheckForPlayer(collision);
            }
        } else {
            CheckForPlayer(collision);
        }

    }

    void DestroyThis() {
        GetComponent<Collider>().enabled = false;
        if (GetComponentInChildren<ParticleSystem>()) {
            GetComponentInChildren<ParticleSystem>().Stop();
            Destroy(gameObject, 2f);
        } else
            Destroy(gameObject);
    }

    void CheckForPlayer(Collision collision) {

        if ((attackProperties.hitLayers.value & 1 << collision.gameObject.layer) != 0) {
            if (collision.collider.GetComponent<UnitProperties>())
                collision.collider.GetComponent<UnitProperties>().TakeDamage(attackProperties.damage, owner.GetComponent<UnitProperties>());
            else if (collision.collider.transform.root.GetComponent<UnitProperties>())
                collision.collider.transform.root.GetComponent<UnitProperties>().TakeDamage(attackProperties.damage, owner.GetComponent<UnitProperties>());
        }
        DestroyThis();
    }

    void FixedUpdate() {
        oldVelocity = GetComponent<Rigidbody>().velocity;
    }
}

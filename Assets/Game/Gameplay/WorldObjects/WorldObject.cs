using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldObject : UnitProperties {

    //public HealthProperties healthProperty;

    public List<GameObject> dropList;
    public bool canTakeDamage = true;
    [Space(1f)]
    public bool damageOnlyFromCharge = false;
    public bool chargeInstantKills = false;
    [Space(1f)]
    public bool destroyFromEMP = false;
    [Space(1f)]
    public bool destructable = false;
    [HideInInspector]
    public bool canTriggerAnimation = true;

    public bool canTriggerTriggerVolume;
    public TriggerVolume volumeToTrigger;

    public List<ParticleSystem> particles;

    protected override void DestroyObject() {

        if (!healthProperty.isAlive) {


            if (particles.Count > 0) {
                foreach (ParticleSystem s in particles) {
                    s.Stop();
                }
            }

            if (canTriggerTriggerVolume)
                volumeToTrigger.Trigger();
            if (dropList.Count > 0) {

                GameObject go = (GameObject)Instantiate(dropList[Random.Range(0, dropList.Count)], transform.position + transform.up * 0.5f, Quaternion.identity);
                if (go.GetComponent<Rigidbody>()) {
                    go.GetComponent<Rigidbody>().AddForce(Vector3.up * 700);
                }
            }
            if (destructable)
                ShatterObject();
            else
                base.DestroyObject();
        }

    }

    public override void TakeDamage(float damage, UnitProperties damageDealer) {
        if (canTakeDamage) {
            if (damageOnlyFromCharge) {
                if (GameController.Player.GetComponent<ShieldCharge>().isCharging) {
                    float damageMultip = chargeInstantKills ? int.MaxValue : 1;
                    base.TakeDamage(damage * damageMultip, damageDealer);
                }
            } else {
                base.TakeDamage(damage, damageDealer);
            }
        }
    }

    void ShatterObject() {
        GetComponent<Collider>().enabled = false;
        Physics.IgnoreCollision(GetComponent<Collider>(), GameController.Player.GetComponent<Collider>());

        //Destroy(gameObject, 5f);

        while (transform.childCount > 0)
            foreach (Transform child in transform) {
                if (child == gameObject)
                    continue;

                if (!child.gameObject.GetComponent<Rigidbody>())
                    child.gameObject.AddComponent<Rigidbody>().mass = 3000;
                child.gameObject.AddComponent<BoxCollider>();
                child.SetParent(null, true);
                Destroy(child.gameObject, Random.Range(3, 4));
                child.GetComponent<Rigidbody>().AddForce((child.position - GameController.Player.transform.position).normalized * 40000, ForceMode.Impulse);
            }
        //GetComponent<Rigidbody>().AddExplosionForce(1000000, transform.position, 1);
    }
}

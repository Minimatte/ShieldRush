using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : UnitProperties {

    private AIProperties aiProperties;

    public GameObject ragdoll;

    void Start() {
        if (!unitMesh)
            unitMesh = transform;

        if (aiProperties == null)
            if (GetComponent<EnemyAI>())
                aiProperties = GetComponent<EnemyAI>().AiProperties;
    }
    public override void TakeDamage(float damage, UnitProperties damageDealer) {
        base.TakeDamage(damage, damageDealer);
        if (gameObject.activeInHierarchy)
            StartCoroutine(ReleaseFromNav());

    }

    IEnumerator ReleaseFromNav() {
        int random = Random.Range(0, 100);
        if (random < 33)
            unitMesh.GetComponent<Animator>().SetTrigger("TakeDamage");
        else
            unitMesh.GetComponent<Animator>().SetTrigger("TakeLowDamage");


        aiProperties.active = false;
        GetComponent<NavMeshAgent>().enabled = false;
        yield return new WaitForSeconds(GetComponent<Enemy>().stunnedTime);
        if (Physics.Raycast(transform.position, -Vector3.up)) {
            aiProperties.active = true;
            GetComponent<NavMeshAgent>().enabled = true;
        }
    }

    protected override void CheckIfAlive() {
        base.CheckIfAlive();
        if (!healthProperty.isAlive) {
            if (aiProperties.deathDrops.Count > 0)
                if (Random.Range(0, 100) < aiProperties.dropChance)
                    Instantiate(aiProperties.deathDrops[Random.Range(0, aiProperties.deathDrops.Count)], transform.position, Quaternion.identity);
        }
    }

    protected override void DestroyObject() {
        GetComponent<EnemyAI>().AiProperties.active = false;

        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<AIBehaviour>().enabled = false;

        if (ragdoll != null) {
            ragdoll.transform.SetParent(null);
            ragdoll.SetActive(true);
            foreach (Rigidbody r in ragdoll.GetComponentsInChildren<Rigidbody>()) {
                r.AddForce(Vector3.up * Random.Range(3000, 6000));
            }
        }
        gameObject.SetActive(false);
        //GetComponent<Rigidbody>().AddForce(Vector3.up * 50000, ForceMode.Impulse);
        //GetComponent<Rigidbody>().AddForce((transform.position - GameController.Player.transform.position) * 50000, ForceMode.Impulse);
        Destroy(ragdoll, 3f);
        Destroy(gameObject, 5f);
    }
}

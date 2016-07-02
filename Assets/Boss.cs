using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            BossHealthBar.instance.SetActive(true);
            BossHealthBar.boss = GetComponent<ShieldedEnemy>();
        }
    }
}

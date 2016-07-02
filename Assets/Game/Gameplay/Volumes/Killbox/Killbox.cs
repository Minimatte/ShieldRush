using UnityEngine;
using System.Collections;

public class Killbox : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        UnitProperties p = other.GetComponent<Player>();
        
        if (p)
            p.TakeDamage(150, p);
    }
}

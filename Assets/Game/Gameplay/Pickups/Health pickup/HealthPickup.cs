using UnityEngine;
using System.Collections;
using System;

public class HealthPickup : Pickup {

    public float healthRegenAmount = 10;

    public override void TriggerPickup(Collider other) {
        other.gameObject.GetComponent<UnitProperties>().GainHealth(healthRegenAmount);
        Destroy(gameObject);
    }
}

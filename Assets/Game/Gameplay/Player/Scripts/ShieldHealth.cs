using UnityEngine;
using System.Collections;

public class ShieldHealth : UnitProperties {



    public override void TakeDamage(float damage, UnitProperties damageDealer) {

        GetComponentInParent<Player>().TakeShieldDamage(damage);

    }
}

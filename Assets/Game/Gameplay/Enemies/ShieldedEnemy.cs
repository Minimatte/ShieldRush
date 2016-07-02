using UnityEngine;
using System.Collections;

public class ShieldedEnemy : Enemy {


    public Transform shield;
    bool isShielded = true;

    public Animator shieldAnimator;

    protected override void ApplyStun(UnitProperties damageDealer) {
        if (!isShielded)
            base.ApplyStun(damageDealer);
        else {
            RemoveShield();
            StartCoroutine(RechargeShield());
        }
    }

    public override void TakeDamage(float damage, UnitProperties damageDealer) {
        if (!isShielded) {
            base.TakeDamage(damage, damageDealer);
        }
    }

    public override void AddStunDuration(float duration) {
        if (!isShielded)
            base.AddStunDuration(duration);
        else {
            RemoveShield();
            StartCoroutine(RechargeShield());

        }
    }

    private void RemoveShield() {
        isShielded = false;
        shieldAnimator.SetTrigger("DestroyShield");
        //Destroy(shield.gameObject);
    }

    private IEnumerator RechargeShield() {
        yield return new WaitForSeconds(10);
        shieldAnimator.SetTrigger("RechargeShield");
        isShielded = true;
    }
}

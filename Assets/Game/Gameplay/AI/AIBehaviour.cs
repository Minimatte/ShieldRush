using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyAI))]
public abstract class AIBehaviour : MonoBehaviour {

    protected EnemyAI ai;
    protected Enemy enemy;
    protected Animator anim;
    private Attack attackComponent;

    public AnimationEnum startAnimation = AnimationEnum.None;

    public virtual void Setup(EnemyAI ai, Enemy enemy) { 
        this.ai = ai;
        this.enemy = enemy;
        attackComponent = GetComponent<Attack>();
        anim = enemy.unitMesh.GetComponent<Animator>();
        SetStartAnimation();

    }
    public abstract void TriggerBehaviour(); 

    void SetStartAnimation() {
        if (anim != null)
            switch (startAnimation) {
                case AnimationEnum.Idle:
                    anim.SetFloat("MoveSpeed", 0);
                    break;
                case AnimationEnum.Run:
                    anim.SetFloat("MoveSpeed", 1);
                    break;
            }
    }


    protected virtual void CheckForAttack() {

        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + transform.forward * enemy.attackProperties.range);
        Physics.BoxCast(transform.position, new Vector3(0.3f, 0.3f, 0.3f), transform.forward, out hit, transform.rotation, enemy.attackProperties.range, enemy.attackProperties.hitLayers);
        if (attackComponent && ai.target && enemy.attackProperties.canAttack && hit.collider != null) {
            if (attackComponent.canAttack) {
                attackComponent.currentCooldown = enemy.attackProperties.attackCooldown;
                StartCoroutine(StopAndAttack(enemy.attackProperties.attackDuration, hit.collider.transform.position));
            }
        }
    }


    protected void LookForTarget() {

        Collider[] hits = Physics.OverlapSphere(transform.position, ai.AiProperties.detectionRange, ai.AiProperties.detectLayers);
        if (hits.Length > 0) {
            foreach (Collider hit in hits) {
                if (hit.CompareTag("Player")) {
                    ai.target = hit.gameObject.transform;
                    GetComponent<UnitSpeech>().Speak(Mood.Aggressive);
                    return;
                }
            }
        }
    }

    protected virtual IEnumerator StopAndAttack(float waitTime, Vector3 target) {
        ai.AiProperties.active = false;

        yield return new WaitForSeconds(waitTime / 2);
        if (enemy.healthProperty.isAlive)
            attackComponent.UseAttack(target);
        yield return new WaitForSeconds(waitTime / 2);
        if (ai.navMeshAgent.isOnNavMesh && enemy.healthProperty.isAlive)
            ai.AiProperties.active = true;
    }

    protected virtual void UpdateTargets() {
        if (ai.target) {
            float distance = Vector3.Distance(ai.target.position, transform.position);
            if (distance > ai.AiProperties.leash) {
                ai.target = null;
            }
        } else {
            ai.navMeshAgent.Stop();
            ai.navMeshAgent.ResetPath();
        }
    }
}

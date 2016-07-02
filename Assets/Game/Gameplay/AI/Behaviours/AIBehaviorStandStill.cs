using UnityEngine;
using System.Collections;
using System;

public class AIBehaviorStandStill : AIBehaviour {
    private const float unitHeightOffset = 0.44f;
    private Vector3 startLoc;

    public override void Setup(EnemyAI ai, Enemy enemy) {
        base.Setup(ai, enemy);
        startLoc = transform.position;

    }

    public override void TriggerBehaviour() { }


    void Update() {
        if (anim)
            anim.SetFloat("MoveSpeed", ai.navMeshAgent.desiredVelocity.normalized.magnitude);
        if (ai.AiProperties.active) {
            if (ai.target) {

                Vector3 direction = (ai.target.transform.position - transform.position).normalized;

                Vector3 targetLoc = new Vector3(ai.target.position.x, ai.target.position.y + unitHeightOffset, ai.target.position.z) - (direction * ai.AiProperties.stopRange);
                if (ai.navMeshAgent.isOnNavMesh)
                    ai.navMeshAgent.destination = targetLoc;

                if (Vector3.Distance(transform.position, targetLoc) <= enemy.attackProperties.range && ai.CanMove) {
                    if (enemy.movementProperties.canRotate) {
                        transform.LookAt(ai.target);
                    }
                }
            } else
                LookForTarget();

            if (!ai.CanMove) {
                ai.navMeshAgent.Stop();
            } else {

                UpdateTargets();
                CheckForAttack();

                if (ai.navMeshAgent.isOnNavMesh)
                    ai.navMeshAgent.Resume();
            }
        }
    }

    protected override void UpdateTargets() {
        if (ai.target) {
            float distance = Vector3.Distance(ai.target.position, transform.position);
            if (distance > ai.AiProperties.leash) {
                ai.target = null;
            }
        } else {
            if (Vector3.Distance(transform.position, startLoc) > 0.5f) {
                if (ai.navMeshAgent.isOnNavMesh)
                    ai.navMeshAgent.SetDestination(startLoc);
            } else {
                ai.navMeshAgent.Stop();
                ai.navMeshAgent.ResetPath();
            }
        }
    }


#if UNITY_EDITOR
    void OnDrawGizmos() {
        if (GenericDebug.gizmosActive && Application.isPlaying) {
            Gizmos.color = (ai.target != null) ? Color.red : Color.white;
            Gizmos.DrawWireSphere(transform.position, ai.AiProperties.detectionRange);
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, ai.AiProperties.leash);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(startLoc, 1f);
        }
    }
#endif
}

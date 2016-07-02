using UnityEngine;
using System.Collections;
using System;


public class AIBehaviourRoam : AIBehaviour {

    private Vector3 patrolLocation;


    public override void TriggerBehaviour() {
        StartCoroutine(PatrolRandomPoints());
    }
    public override void Setup(EnemyAI ai, Enemy enemy) {
        base.Setup(ai, enemy);
        StartCoroutine(PatrolRandomPoints());
    }

    void Update() {
        if (anim)
            anim.SetFloat("MoveSpeed", ai.navMeshAgent.desiredVelocity.normalized.magnitude);
        if (ai.AiProperties.active) {
            if (ai.target) {

                Vector3 direction = ai.target.transform.position - transform.position;
                direction.Normalize();
                Vector3 targetLoc = new Vector3(ai.target.position.x, ai.target.position.y + 0.44f, ai.target.position.z) - (direction * ai.AiProperties.stopRange);
                ai.navMeshAgent.destination = targetLoc;

                if (Vector3.Distance(transform.position, ai.target.transform.position) < ai.AiProperties.stopRange && ai.CanMove) {

                    if (enemy.movementProperties.canRotate)
                        transform.LookAt(ai.target);
                } else {


                    if (!ai.CanMove) {
                        ai.navMeshAgent.Stop();
                    } else {
                        ai.navMeshAgent.Resume();
                    }
                }
            } else
                LookForTarget();


            if (ai.CanMove && ai.AiProperties.active) {
                UpdateTargets();
                CheckForAttack();
            }

        }
    }


    public IEnumerator PatrolRandomPoints() {
        bool arrived = true;

        float timeStandingStill = 0;
        Vector3 lastPosition = transform.position;
        if (ai.navMeshAgent.isOnNavMesh)
            while (true) {
                if (enemy.stunnedTime <= 0)
                    if (ai.navMeshAgent.isOnNavMesh)
                        ai.navMeshAgent.Resume();



                if (!ai.target && ai.AiProperties.active && enemy.stunnedTime <= 0) {

                    if (Vector3.Distance(lastPosition, transform.position) <= 0.01f)
                        timeStandingStill += Time.deltaTime;

                    lastPosition = transform.position;

                    if (Vector3.Distance(transform.position, patrolLocation) < 1 && !arrived) {
                        arrived = true;
                        yield return new WaitForSeconds(1f);
                    }

                    if (arrived || timeStandingStill >= 3) {
                        arrived = false;
                        do {
                            patrolLocation = transform.position + UnityEngine.Random.insideUnitSphere * ai.AiProperties.detectionRange;
                            patrolLocation.y = transform.position.y;
                        } while (!NavMesh.CalculatePath(transform.position, patrolLocation, ai.navMeshAgent.areaMask, new NavMeshPath()));

                        timeStandingStill = 0;

                    } else
                        ai.navMeshAgent.destination = patrolLocation;
                }
                yield return 0;
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
            Gizmos.DrawWireSphere(patrolLocation, 1f);
        }
    }
#endif
}

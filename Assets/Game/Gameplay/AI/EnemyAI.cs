using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyAI : MonoBehaviour {
    [SerializeField]
    private AIProperties aiProperties;
    public AIProperties AiProperties { get { return aiProperties; } }

    internal Transform target;
    internal NavMeshAgent navMeshAgent;

    private Enemy enemyComponent;

    private AIBehaviour behaviour;

    public bool CanMove {
        get { return enemyComponent.stunnedTime <= 0 && enemyComponent.movementProperties.canMove; }
    }

    void Awake() {

        if (GetComponents<AIBehaviour>().Length == 1) // get the behavior, if none, it will stand still and do nothing. It will be "dead".
            behaviour = GetComponent<AIBehaviour>();
        else if (GetComponents<AIBehaviour>().Length > 1)
            throw new Exception("Too many behaviours on an enemy!");

        enemyComponent = GetComponent<Enemy>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        Setup();

    }

    void Setup() { // setup the nav mesh agent and trigger the behavior if it exits

        navMeshAgent.speed = enemyComponent.movementProperties.movementSpeedBase;
        navMeshAgent.angularSpeed = enemyComponent.movementProperties.rotationSpeed;
        if (navMeshAgent.baseOffset == 0)
            navMeshAgent.baseOffset = 0.5f;

        if (behaviour) {
            behaviour.Setup(this, enemyComponent);
            behaviour.TriggerBehaviour();
        }
    }

    void ToggleAI() {
        if (navMeshAgent.enabled) {
            navMeshAgent.Stop();
            navMeshAgent.ResetPath();
        }
        navMeshAgent.enabled = !navMeshAgent.enabled;
    }

    public void KnockAwayAI(Vector3 force, ForceMode mode) {
        StartCoroutine(KnockAway(force, mode));
    }

    IEnumerator KnockAway(Vector3 force, ForceMode mode) {
        aiProperties.active = false;
        GetComponent<Rigidbody>().AddForce(force, mode);
        yield return new WaitForSeconds(0.2f);
        aiProperties.active = true;
    }
}

using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class AIBehaviourAnimation : AIBehaviour {

    public bool killWhenDone = true;
    public bool mustTrigger = false;
    public List<AIEvent> EventList;

    AIEvent currentEvent;
    bool eventOngoing = false;


    public override void TriggerBehaviour() {
        if (!mustTrigger)
            if (EventList.Count > 0) {
                StartCoroutine(PopEvent());
            } else {
                if (killWhenDone)
                    Destroy(gameObject);
            }
    }

    public void TriggerEvent() {

        if (EventList.Count > 0) {
            StartCoroutine(PopEvent());
        } else {
            if (killWhenDone)
                Destroy(gameObject);
        }
    }

    IEnumerator PopEvent() {
        yield return new WaitForSeconds(EventList[0].startDelay);
        currentEvent = EventList[0];
        EventList.Remove(EventList[0]);
        GetComponent<UnitSpeech>().Speak(currentEvent.mood);
        MoveToWaypoint();
        eventOngoing = true;
        ai.navMeshAgent.speed = currentEvent.moveSpeed;
        UpdateAnimation();
    }

    void LateUpdate() {
        if (eventOngoing)
            CheckIfReachedDestination();
    }

    void CheckIfReachedDestination() {

        if (!ai.navMeshAgent.pathPending) {
            if (ai.navMeshAgent.remainingDistance <= ai.navMeshAgent.stoppingDistance) {
                if (!ai.navMeshAgent.hasPath || ai.navMeshAgent.velocity.sqrMagnitude == 0f) {
                    if (EventList.Count > 0) { // is there another event after this?
                        StartCoroutine(PopEvent());
                        eventOngoing = false;
                    } else {
                        if (killWhenDone)
                            Destroy(gameObject);
                    }
                }
            }
        }
    }

    void UpdateAnimation() {
        if (currentEvent != null) {
            if (startAnimation != AnimationEnum.None)
                startAnimation = AnimationEnum.None;
            switch (currentEvent.animation) {
                case AnimationEnum.Idle:
                    anim.SetFloat("MoveSpeed", 0);
                    break;
                case AnimationEnum.Run:
                    anim.SetFloat("MoveSpeed", 1);
                    break;
                case AnimationEnum.Attack:
                    anim.SetTrigger("Attack");
                    break;
                case AnimationEnum.Taunt:
                    anim.SetTrigger("Taunt");
                    break;
                case AnimationEnum.Point:
                    anim.SetTrigger("Point");
                    break;
                case AnimationEnum.Hurt:
                    anim.SetTrigger("Hurt");
                    break;
            }

        }
    }

    void MoveToWaypoint() {
        if (currentEvent.waypoint != null)
            ai.navMeshAgent.destination = currentEvent.waypoint.position;
    }

}

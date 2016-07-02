using UnityEngine;
using System.Collections;
using System;

public class AnimationTriggerVolume : Interactable {

    public Animator anim;
    public string triggerName = "Trigger";

    public bool useOnce = true;
    private bool hasUsed = false;

    void Awake() {
        if (anim == null)
            throw new Exception("You must assign an animator to the animation triggervolume (" + name + ")");
    }
    public override void Interact() {
        if (useOnce) {
            if (!hasUsed) {
                anim.SetTrigger(triggerName);
                hasUsed = true;
            }
        } else {
            anim.SetTrigger(triggerName);
        }
    }

}

using UnityEngine;
using System.Collections;

public class EMPTrigger : MonoBehaviour {

    public TriggerVolume triggerThisVolume;

    public void Trigger() {
        triggerThisVolume.Trigger();
    }
}

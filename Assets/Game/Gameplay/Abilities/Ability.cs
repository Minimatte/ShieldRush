using UnityEngine;

[System.Serializable]
public class AbilityProperties {

    [HideInInspector]
    public bool modified;
    public bool hasLearnt = false;
    public bool upgraded = false;
    public float modifiedMaxCooldown = 1;
    public float modifiedCurrentCooldown = 0;

    public float unmodifiedMaxCooldown = 1;
    public float unmodifiedCurrentCooldown = 0;

    public bool canUse = true;
    public float UnmodifiedCooldownPercentage { get { return unmodifiedCurrentCooldown / unmodifiedMaxCooldown; } }
    public float ModifiedCooldownPercentage { get { return modifiedCurrentCooldown / modifiedMaxCooldown; } }

    public bool ModifiedCooldownReady {
        get { return modifiedCurrentCooldown == 0; }
    }

    public bool UnmodifiedCooldownReady {
        get { return unmodifiedCurrentCooldown == 0; }
    }

    public Sprite abilityIcon;
}

public abstract class Ability : MonoBehaviour {

    public AbilityProperties abilityProperties;

    public abstract void UseAbility(bool modified);

    void Update() {
        if (abilityProperties.modifiedCurrentCooldown > 0) {
            abilityProperties.modifiedCurrentCooldown -= Time.deltaTime;
            abilityProperties.modifiedCurrentCooldown = Mathf.Clamp(abilityProperties.modifiedCurrentCooldown, 0, abilityProperties.modifiedMaxCooldown);
        }
        if (abilityProperties.unmodifiedCurrentCooldown > 0) {
            abilityProperties.unmodifiedCurrentCooldown -= Time.deltaTime;
            abilityProperties.unmodifiedCurrentCooldown = Mathf.Clamp(abilityProperties.unmodifiedCurrentCooldown, 0, abilityProperties.unmodifiedMaxCooldown);
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AbilityHandler : MonoBehaviour {

    void Start() {

        foreach (Ability a in GetComponents<Ability>()) {
            if (a.abilityProperties.hasLearnt)
                GameController.learntAbilities[a.GetType().ToString()] = true;
            else
                GameController.learntAbilities[a.GetType().ToString()] = false;

            if (a.abilityProperties.upgraded)
                GameController.upgradedAbilities[a.GetType().ToString()] = true;
            else
                GameController.upgradedAbilities[a.GetType().ToString()] = false;

        }

    }

    public void AddAbility(Type ability) {
        Ability temp = GameController.Player.GetComponent(ability) as Ability;
        if (temp.abilityProperties.hasLearnt) {
            temp.abilityProperties.upgraded = true;
            GameController.upgradedAbilities[temp.GetType().ToString()] = true;

        } else {
            temp.abilityProperties.hasLearnt = true;
            GameController.learntAbilities[temp.GetType().ToString()] = true;

        }

    }
}

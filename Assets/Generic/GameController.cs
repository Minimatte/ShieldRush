using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameObject Player;

    public static Checkpoint lastCheckpoint;
    public static GameObject ragdoll;
    public static bool isPaused = false;
    public static Dictionary<string, bool> learntAbilities;
    public static Dictionary<string, bool> upgradedAbilities;

    public ScreenFader fader;
    private static ScreenFader faderStatic;

    [SerializeField]
    private GameObject playerPrefab;
    private static GameObject playerPrefabStatic;
    void Awake() {

        faderStatic = fader;
        learntAbilities = new Dictionary<string, bool>();
        upgradedAbilities = new Dictionary<string, bool>();
        if (Player == null) {
            Player = GameObject.FindGameObjectWithTag("Player"); // eugh... gör inte så
        }
        if (playerPrefab == null)
            throw new System.Exception("You have to assign a player prefab to the game controller");
        else {
            playerPrefabStatic = playerPrefab;
        }

    }

    void Update() {
        if (Input.anyKeyDown && UIManager.RespawnPanelOpen) {
            UIManager.HideRespawnUI();
            RespawnPlayer();
        }
    }

    public void RespawnPlayer() {
        GameObject go = Instantiate(playerPrefabStatic, lastCheckpoint.gameObject.transform.position + Vector3.up * 0.5f, Quaternion.identity) as GameObject;
        Player = go;
        CameraMovement cm = Camera.main.GetComponent<CameraMovement>();
        cm.player = Player;
        cm.camSize = cm.startCamSize;

        Camera.main.GetComponent<AudioListener>().enabled = false;

        Destroy(ragdoll);

        EMP emp = go.GetComponent<EMP>();
        SetAbilityValues(emp);
        ShieldCharge charge = go.GetComponent<ShieldCharge>();
        SetAbilityValues(charge);
        ShieldBash bash = go.GetComponent<ShieldBash>();
        SetAbilityValues(bash);
    }

    private void SetAbilityValues(Ability ability) {
        ability.abilityProperties.hasLearnt = learntAbilities[ability.GetType().ToString()];
        ability.abilityProperties.upgraded = upgradedAbilities[ability.GetType().ToString()];
    }


    public static void FadeToBlack() {
        faderStatic.EndScene();
        UIManager.HideUI();
    }

}

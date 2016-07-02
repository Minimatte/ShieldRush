using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;

public class GenericDebug : MonoBehaviour {

    public static bool gizmosActive;
    public static bool showStats;

    void OnGUI() {
        if (showStats) {
            GUI.Label(new Rect(0, 0, 2000, 20), "FPS: " + (1 / Time.deltaTime));
            GUI.Label(new Rect(0, 15, 2000, 20), "Scene: " + SceneManager.GetActiveScene().name);
            GUI.Label(new Rect(0, 30, 2000, 20), "Time: " + Time.timeSinceLevelLoad);
            if (GameController.Player) {
                GUI.Label(new Rect(0, 45, 2000, 20), "Player pos: " + GameController.Player.transform.position);
                GUI.Label(new Rect(0, 60, 2000, 20), "Player health: " + GameController.Player.GetComponent<Player>().healthProperty.currentHealth);
            }
        }
    }
#if UNITY_EDITOR

    public static void ToggleStats() {
        showStats = !showStats;
    }

    public static void SetMoveSpeed(float moveSpeed) {

        GameController.Player.GetComponent<Player>().movementProperties.movementSpeedBase = moveSpeed;

    }

    public static void SetPlayerDamage(float damage) {
        GameController.Player.GetComponent<Player>().attackProperties.damage = damage;
    }

    [MenuItem("Debug/Show Gizmos")]
    public static void ToggleGizmos() {
        gizmosActive = !gizmosActive;
        Menu.SetChecked("Debug/Show Gizmos", gizmosActive);
    }

    public static Vector3 GetPlayerLocation() {
        return GameController.Player.transform.position;
    }

    public static void ToggleAI() {
        EnemyAI[] ais = FindObjectsOfType<EnemyAI>();
        foreach (EnemyAI ai in ais) {
            ai.AiProperties.active = !ai.AiProperties.active;
        }
    }

    public static void TogglePlayerInvincibility() {
        Player[] players = FindObjectsOfType<Player>();
        foreach (Player p in players) {
            p.healthProperty.invincible = !p.healthProperty.invincible;
        }
    }

    public static void MoveToLocation(int x, int y, int z) {
        SceneView.lastActiveSceneView.pivot = new Vector3(x, y, z);
    }
#endif
}


using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
#if UNITY_EDITOR
public class DebugWindow : EditorWindow {

    private GenericDebug debug;

    [MenuItem("Debug/Show Window")]
    public static void ShowWindow() {
        GetWindow(typeof(DebugWindow));
    }
    float speedValue = 0.0F;
    float damageValue = 0.0F;

    private string x = "0", y = "0", z = "0";
    void OnGUI() {

        if (Application.isPlaying)
            GUI.enabled = true;
        else
            GUI.enabled = false;

        if (GUI.Button(new Rect(0, 0, position.width, 25), "Toggle AI")) {
            GenericDebug.ToggleAI();
        }

        if (GUI.Button(new Rect(0, 25, position.width, 25), "Toggle Player Invincibility")) {
            GenericDebug.TogglePlayerInvincibility();
        }
        x = GUI.TextField(new Rect(0, 50, 50, 30), x);
        y = GUI.TextField(new Rect(50, 50, 50, 30), y);
        z = GUI.TextField(new Rect(100, 50, 50, 30), z);


        if (GUI.Button(new Rect(150, 50, 100, 30), "Move To X,Y,Z")) {
            GenericDebug.MoveToLocation(int.Parse(x), int.Parse(y), int.Parse(z));
        }

        GUI.Label(new Rect(250, 50, 200, 50), "FPS: " + 1 / Time.deltaTime);

        if (GUI.Button(new Rect(0, 75, position.width, 25), "Toggle Stats")) {
            GenericDebug.ToggleStats();
        }

        speedValue = GUI.HorizontalSlider(new Rect(300, 105, 105, 30), speedValue, 0.0F, 100F);
        GUI.Label(new Rect(205, 105, 105, 30), "speed " + speedValue);
        if (GUI.Button(new Rect(0, 100, 150, 25), "Set Move speed")) {
            GenericDebug.SetMoveSpeed(speedValue);
        }

        damageValue = GUI.HorizontalSlider(new Rect(300, 125, 105, 30), damageValue, 0.0F, 100F);
        GUI.Label(new Rect(205, 125, 105, 30), "damage " + damageValue);
        if (GUI.Button(new Rect(0, 125, 150, 25), "Set Damage")) {
            GenericDebug.SetPlayerDamage(damageValue);
        }

    }
}
#endif

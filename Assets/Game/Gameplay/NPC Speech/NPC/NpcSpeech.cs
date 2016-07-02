using UnityEngine;
using System.Collections;

public class NpcSpeech : MonoBehaviour {

    public TextAsset theText;
    public Sprite dialogSprite;
    public int startLine;
    public int endLine;
    public TextBoxManager textManager;
    public bool destroyWhenActivated;
    public bool requireButtonPress;
    private bool waitForPress;
    public bool stoptime = false;

    void Start() {

        textManager = FindObjectOfType<TextBoxManager>();
    }


    void Update() {

        if (waitForPress && Input.GetKeyDown(KeyCode.F)) {

            ActivateText();

        }

    }
    void OnTriggerEnter(Collider other) {

        if (other.name == "Player") {
            if (requireButtonPress) {
                waitForPress = true;
                return;
            }
            ActivateText();

        }
    }

    void OnTriggerExit(Collider other) {

        if (other.name == "Player") {

            waitForPress = false;
        }
    }

    void ActivateText() {

        textManager.ReloadScript(theText);
        textManager.currentLine = startLine;
        textManager.SetImage(dialogSprite);
        textManager.stopTime = stoptime;
        textManager.EnableTextBox();


        if (destroyWhenActivated) {

            Destroy(gameObject);
        }
    }
}


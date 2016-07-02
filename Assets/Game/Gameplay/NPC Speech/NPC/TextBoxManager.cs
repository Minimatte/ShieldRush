using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    [SerializeField]
    GameObject textPanel;
    [SerializeField]
    Text theText;
    [SerializeField]
    Image dialogImage;
    public string[] textLines;
    public int currentLine;
    public int endAtLine;

    public bool isActive;
    private bool isTyping = false;
    private bool cancelTyping = false;
    public float typeSpeed;

    internal bool stopTime = false;

    void Start() {
        if (isActive)
            EnableTextBox();
        else
            DisableTextBox();
    }

    void Update() {
        if (!isActive)
            return;

        if (Input.GetKeyDown(KeyCode.Return)) {
            if (!isTyping) {
                currentLine += 1;
                if (currentLine > endAtLine)
                    DisableTextBox();
                else
                    StartCoroutine(TextScroll(textLines[currentLine]));

            } else if (isTyping && !cancelTyping)
                cancelTyping = true;
        }
    }

    private IEnumerator TextScroll(string lineOfText) {

        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1)) {

            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }

        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableTextBox() {

        textPanel.SetActive(true);
        isActive = true;
        //Stänger av spelarens röresle när man snackar
        Player p = GameController.Player.GetComponent<Player>();
        p.movementProperties.canMove = false;
        p.attackProperties.canAttack = false;
        p.rollProperties.canRoll = false;

        StartCoroutine(TextScroll(textLines[currentLine]));
        if (stopTime)
            Time.timeScale = 0;
    }

    public void DisableTextBox() {

        textPanel.SetActive(false);
        isActive = false;
        //Nu kan man röra sig efter att man har snackat
        Player p = GameController.Player.GetComponent<Player>();
        p.movementProperties.canMove = true;
        p.attackProperties.canAttack = true;
        p.rollProperties.canRoll = true;
        if (stopTime)
            Time.timeScale = 1;
    }

    public void ReloadScript(TextAsset theText) {

        if (theText != null) {

            textLines = theText.text.Split('\n');

            if (endAtLine == 0) {
                endAtLine = textLines.Length - 1;
            }
        }
    }

    public void SetImage(Sprite newImage) {

        dialogImage.sprite = newImage;
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuScript : MonoBehaviour {
    [SerializeField]
    Animator introCinematic;

    [SerializeField]
    Canvas startMenu;
    [SerializeField]
    Canvas exitMenu;

    [SerializeField]
    Animator playButton;
    [SerializeField]
    Animator exitButton;
    [SerializeField]
    Animator yesButton;
    [SerializeField]
    Animator noButton;

    [SerializeField]
    Image playCirkleBar;
    [SerializeField]
    Image optionsCirkleBar;
    [SerializeField]
    Image exitCirkleBar;
    [SerializeField]
    Image yesCirkleBar;
    [SerializeField]
    Image noCirkleBar;

    [SerializeField]
    MenuAudio audioManager;

    public static bool inMenu = true;

    public bool hoverSound = true;
    public GameObject playerUI;
    public float slideOutSpeed = 1.0f;
    public float slideInSpeed = 1.5f;

    public List<AIBehaviourAnimation> startEnemies;

    //public float animationClipTime;

    private int buttonSelected = 0;

    void Start() {

        //Längden på klippet
        //animationClipTime = startMenuSlide.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;

        //Hur långt klippet hart kommit
        //float currentStateProgress = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;

        startMenu = startMenu.GetComponent<Canvas>();
        playButton = playButton.GetComponent<Animator>();
        exitButton = exitButton.GetComponent<Animator>();
        yesButton = yesButton.GetComponent<Animator>();
        noButton = noButton.GetComponent<Animator>();
        exitMenu.enabled = false;
        startMenu.enabled = true;
        yesButton.GetComponent<Button>().interactable = false;
        noButton.GetComponent<Button>().interactable = false;
        SlideOutExit();

    }

    private int inExit = 0;
    void Update() {

        if (inMenu) {
            if (Input.GetButtonDown("Cancel") || Input.GetButtonDown("Roll")) {
                switch (buttonSelected) {
                    case 0:
                        StartLevel();
                        break;
                    case 1:
                        ExitPress();
                        buttonSelected = 2;
                        inExit = 2;
                        break;
                    case 2:
                        Application.Quit();
                        break;
                    case 3:
                        NoPress();
                        buttonSelected = 0;
                        inExit = 0;
                        exitCirkleBar.fillAmount = 1;
                        break;
                }
            }

            if (Input.GetAxisRaw("Vertical") > 0.9 || Input.GetAxisRaw("Vertical") < -0.9) {

                buttonSelected -= (int)Input.GetAxisRaw("Vertical");
                buttonSelected = Mathf.Clamp(buttonSelected, 0 + inExit, 1 + inExit);
            }

            switch (buttonSelected) {
                case 0:
                    playButton.GetComponent<Button>().Select();
                    break;
                case 1:
                    exitButton.GetComponent<Button>().Select();
                    break;
                case 2:
                    yesButton.GetComponent<Button>().Select();
                    break;
                case 3:
                    noButton.GetComponent<Button>().Select();
                    break;
            }
        }

    }


    public void HoverSound() {
        if (hoverSound) {
            audioManager.HoverSoundPlay();
        }
    }

    private void EnableHoverSound() {
        hoverSound = true;

    }
    private void DisableHoverSound() {
        hoverSound = false;

    }

    public void StartLevel() {
        CinematicManager.canCancel = true;
        inMenu = false;
        DisablePlay();
        Invoke("SlideOutPlay", slideOutSpeed);
        StartCoroutine(PlayCirkleBarSubtractor());
        audioManager.ActivateSoundPlay();
        DisableHoverSound();
        introCinematic.SetTrigger("Intro");

    }

    public void OptionsPress() {
        DisablePlay();
        Invoke("SlideOutPlay", slideOutSpeed);
        StartCoroutine(OptionsCirkleBarSubtractor());
        audioManager.ActivateSoundPlay();
        DisableHoverSound();

    }

    public void ExitPress() {
        DisablePlay();
        Invoke("SlideOutPlay", slideOutSpeed);
        Invoke("SlideInExit", slideInSpeed);
        exitMenu.enabled = true;
        StartCoroutine(ExitCirkleBarSubtractor());
        audioManager.ActivateSoundPlay();
        DisableHoverSound();
    }

    public void YesPress() {
        DisableExit();
        Invoke("SlideOutExit", slideOutSpeed);
        Debug.Log("Exit Game");
        StartCoroutine(YesCirkleBarSubtractor());
        audioManager.ActivateSoundPlay();
        DisableHoverSound();
    }

    public void NoPress() {
        DisableExit();
        Invoke("SlideOutExit", slideOutSpeed);
        Invoke("SlideInPlay", slideInSpeed);
        StartCoroutine(NoCirkleBarSubtractor());
        audioManager.DeactivateSoundPlay();
        DisableHoverSound();
    }

    public void SlideOutPlay() {
        playButton.SetTrigger("Slide Out");
        exitButton.SetTrigger("Slide Out");

    }

    public void SlideInPlay() {
        playButton.SetTrigger("Slide In");
        exitButton.SetTrigger("Slide In");
        Invoke("EnablePlay", slideOutSpeed);
        playCirkleBar.fillAmount = 1;
        optionsCirkleBar.fillAmount = 1;
        exitCirkleBar.fillAmount = 1;
        Invoke("EnableHoverSound", slideOutSpeed);

    }

    public void SlideInExit() {
        yesButton.SetTrigger("Slide In");
        noButton.SetTrigger("Slide In");
        Invoke("EnableExit", slideOutSpeed);
        yesCirkleBar.fillAmount = 1;
        noCirkleBar.fillAmount = 1;
        Invoke("EnableHoverSound", slideOutSpeed);

    }

    public void SlideOutExit() {
        yesButton.SetTrigger("Slide Out");
        noButton.SetTrigger("Slide Out");

    }

    public void EnablePlay() {
        playButton.GetComponent<Button>().interactable = true;
        exitButton.GetComponent<Button>().interactable = true;
    }

    public void DisablePlay() {
        playButton.GetComponent<Button>().interactable = false;
        exitButton.GetComponent<Button>().interactable = false;
    }

    public void EnableExit() {
        yesButton.GetComponent<Button>().interactable = true;
        noButton.GetComponent<Button>().interactable = true;
    }

    public void DisableExit() {
        yesButton.GetComponent<Button>().interactable = false;
        noButton.GetComponent<Button>().interactable = false;
    }

    IEnumerator PlayCirkleBarSubtractor() {
        while (playCirkleBar.fillAmount != 0) {

            playCirkleBar.fillAmount -= 1f * Time.deltaTime;
            yield return 0;
        }

        yield return new WaitForSeconds(0.3f);


        foreach (AIBehaviourAnimation enemy in startEnemies) {
            enemy.mustTrigger = false;
            enemy.TriggerEvent();

        }
        // playerUI.SetActive(true);

        //Application.LoadLevel("Scene");

    }

    IEnumerator OptionsCirkleBarSubtractor() {
        while (optionsCirkleBar.fillAmount != 0) {

            optionsCirkleBar.fillAmount -= 1f * Time.deltaTime;
            yield return 0;
        }
    }

    IEnumerator ExitCirkleBarSubtractor() {
        while (exitCirkleBar.fillAmount != 0) {

            exitCirkleBar.fillAmount -= 1f * Time.deltaTime;
            yield return 0;
        }
    }

    IEnumerator YesCirkleBarSubtractor() {
        while (yesCirkleBar.fillAmount != 0) {

            yesCirkleBar.fillAmount -= 1f * Time.deltaTime;
            yield return 0;
        }
    }

    IEnumerator NoCirkleBarSubtractor() {
        while (noCirkleBar.fillAmount != 0) {

            noCirkleBar.fillAmount -= 1f * Time.deltaTime;
            yield return 0;
        }
    }

}

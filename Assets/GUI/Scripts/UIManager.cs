using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    public GameObject respawnPanel;
    private static GameObject respawnPanelStatic;

    public GameObject menuPanel;
    private static GameObject menuPanelStatic;

    public Image playerHealthBar;
    public Image playerHealthBarEffect;
    public Image playerShieldBar;
    public Image playerShieldBarEffect;

    private static Image shieldBarStatic;
    private static Image healthBarStatic;

    public static bool RespawnPanelOpen { get { return respawnPanelStatic.activeInHierarchy; } }

    public Image reflectIcon;
    public Image chargeIcon;
    public Image empIcon;
    private static Image ReflectIcon;
    private static Image ChargeIcon;
    private static Image EmpIcon;


    public static void TakeDamageAnimation() {
        healthBarStatic.GetComponent<Animator>().SetTrigger("TakeDamage");
    }

    public static void LowManaAnimation() {
        shieldBarStatic.GetComponent<Animator>().SetTrigger("LowMana");
    }

    void Awake() {

        shieldBarStatic = playerShieldBar;
        healthBarStatic = playerHealthBar;

        ReflectIcon = reflectIcon;
        ChargeIcon = chargeIcon;
        EmpIcon = empIcon;

        if (respawnPanel == null)
            throw new System.Exception("Assign respawn panel to the UI manager");
        else
            respawnPanelStatic = respawnPanel;

        if (menuPanel == null)
            throw new System.Exception("Assign menu panel to the UI manager");
        else
            menuPanelStatic = menuPanel;

    }

    public static void ShowRespawnUI() {

        respawnPanelStatic.SetActive(true);

    }
    public static void HideRespawnUI() {

        respawnPanelStatic.SetActive(false);

    }

    public static void ShowPauseMenu() {
        menuPanelStatic.SetActive(true);
    }

    public static void HidePauseMenu() {
        menuPanelStatic.SetActive(false);
    }

    void Update() {
        if (Input.GetButtonDown("Cancel") && !CinematicManager.canCancel && !MenuScript.inMenu) {
            if (!GameController.isPaused) {
                ShowPauseMenu();
                PauseGame();
            } else {
                menuPanelStatic.SetActive(false);
                HidePauseMenu();
                UnpauseGame();
            }
        }

        if (GameController.Player != null) {

            HealthProperties hp = GameController.Player.GetComponent<Player>().healthProperty;
            ShieldProperties sp = GameController.Player.GetComponent<Player>().shieldProperties;


            float currentHealth = hp.currentHealth;
            float maxHealth = hp.maxHealth;

            float currentShieldHealth = sp.currentShieldHealth;
            float maxShieldHealth = sp.maxShieldHealth;

            float targetHpEffect = currentHealth / maxHealth;
            float targetHp = currentHealth / maxHealth;
            float targetSp = currentShieldHealth / maxShieldHealth;

            playerHealthBar.fillAmount = targetHp;
            playerShieldBar.fillAmount = targetSp;// Mathf.Lerp(playerShieldBar.fillAmount, targetSp, 30 * Time.deltaTime);

            playerHealthBarEffect.fillAmount = Mathf.Lerp(playerHealthBarEffect.fillAmount, targetHpEffect, 2 * Time.deltaTime);
            playerShieldBarEffect.fillAmount = Mathf.Lerp(playerShieldBarEffect.fillAmount, targetSp, 8 * Time.deltaTime);


        } else {
            playerHealthBarEffect.fillAmount = Mathf.Lerp(playerHealthBarEffect.fillAmount, 0, 2 * Time.deltaTime);
            playerShieldBarEffect.fillAmount = Mathf.Lerp(playerShieldBarEffect.fillAmount, 0, 2 * Time.deltaTime);

            playerHealthBar.fillAmount = Mathf.Lerp(playerHealthBar.fillAmount, 0, 12 * Time.deltaTime);
            playerShieldBar.fillAmount = Mathf.Lerp(playerShieldBar.fillAmount, 0, 12 * Time.deltaTime);
        }
    }


    public static void PauseGame() {
        Time.timeScale = 0;
        GameController.isPaused = true;
        ShowPauseMenu();

    }
    public void UnpauseGame() {
        GameController.isPaused = false;
        Time.timeScale = 1;
    }
    public static void UnpauseGameGlobal() {
        GameController.isPaused = false;
        Time.timeScale = 1;
        HidePauseMenu();
    }

    public static void LearnReflect() {
        ReflectIcon.gameObject.SetActive(true);
    }

    public static void LearnCharge() {
        ChargeIcon.gameObject.SetActive(true);
    }

    public static void LearnEMP() {
        EmpIcon.gameObject.SetActive(true);
    }

    public static void HideUI() {
        menuPanelStatic.transform.root.gameObject.SetActive(false);
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CinematicManager : MonoBehaviour {

    public Animator playerAnimator, companionAnimator, bigRobotAnimator;
    public List<Animator> smallRobotsMelee, smallRobotsRange;
    internal static bool canCancel = false;
    [SerializeField]
    GameObject cinematicTicketBoss;
    [SerializeField]
    GameObject cinematicTicketPlayer;
    [SerializeField]
    GameObject shieldCinematic;

    [SerializeField]
    GameObject playerCinematic;
    [SerializeField]
    GameObject bossCinematic;

    public Transform spawnPosition;
    public GameObject player;

    public GameObject cinematicPlayerReference, cinematicCompanionReference;
    public GameObject mainCameraPrefab;
    private GameObject cinematicCamera;
    private GameObject spawnedPlayer;

    public Object GameControllerScene;
    public GameObject UI;
    void Start() {
        cinematicTicketBoss.GetComponent<Renderer>().enabled = false;
        cinematicTicketPlayer.GetComponent<Renderer>().enabled = false;
        ShieldCinematicNotVisable();
        cinematicCamera = Camera.main.gameObject;
    }
    public void SpawnPlayer() {
        PlayerMovement.PlayerActive = false;
        spawnedPlayer = Instantiate(player, spawnPosition.position, spawnPosition.rotation) as GameObject;
        cinematicPlayerReference.SetActive(false);
        cinematicCompanionReference.SetActive(false);
        GameController.Player = spawnedPlayer;
    }

    void Update() {
        if (Input.GetButtonDown("Cancel") && canCancel) {
            Invoke("setCanCancel", 0.1f);
            GetComponent<Animator>().Stop();
            Destroy(cinematicTicketBoss.gameObject);
            Destroy(playerCinematic);
            Destroy(bossCinematic);
            SpawnPlayer();
            ActivatePlayer();
            if (GameController.isPaused)
                UIManager.UnpauseGameGlobal();
            Destroy(gameObject);
        }
    }

    private void setCanCancel() {
        canCancel = false;
    }

    public void ActivatePlayer() {
        canCancel = false;
        PlayerMovement.PlayerActive = true;
        GameObject go = Instantiate(mainCameraPrefab) as GameObject;
        go.GetComponent<CameraMovement>().startCamSize = 108f;
        go.transform.position = new Vector3(go.transform.position.x, 125f, go.transform.position.z);
        go.GetComponent<CameraMovement>().player = spawnedPlayer;
        cinematicCamera.SetActive(false);
        UI.SetActive(true);
        //SceneManager.LoadSceneAsync(GameControllerScene.name, LoadSceneMode.Additive);
        GameController.Player.GetComponent<AbilityHandler>().enabled = true;
    }

    public void CinematicTicketPlayerVisable() {
        cinematicTicketPlayer.GetComponent<Renderer>().enabled = true;
    }
    public void CinematicTicketBossVisable() {
        cinematicTicketBoss.GetComponent<Renderer>().enabled = true;
        cinematicTicketPlayer.GetComponent<Renderer>().enabled = false;
    }
    public void ShieldCinematicVisable() {
        shieldCinematic.GetComponent<SkinnedMeshRenderer>().enabled = true;
    }
    public void ShieldCinematicNotVisable() {
        shieldCinematic.GetComponent<SkinnedMeshRenderer>().enabled = false;
    }

    public void TriggerTriggerVolume(TriggerVolume volume) {
        volume.Trigger();
    }

    public void PlayerIdle() {
        playerAnimator.SetTrigger("Idle");
    }
    public void PlayerCombatIdle() {
        playerAnimator.SetTrigger("CombatIdle");
    }
    public void PlayerHurt() {
        playerAnimator.SetTrigger("Hurt");
    }
    public void PlayerTalkYes() {
        playerAnimator.SetTrigger("TalkYes");
    }
    public void PlayerTalkNo() {
        playerAnimator.SetTrigger("TalkNo");
    }
    public void PlayerTripping() {
        playerAnimator.SetTrigger("Tripping");
    }
    public void PlayerTalkNeutral() {
        playerAnimator.SetTrigger("TalkNeutral");
    }

    public void BigRobotRightPunch() {
        bigRobotAnimator.SetTrigger("RightPunch");
    }
    public void BigRobotIdle() {
        bigRobotAnimator.SetTrigger("Idle");
    }
    public void BigRobotWalk() {
        bigRobotAnimator.SetFloat("MoveSpeed", 1);
    }
    public void BigRobotTaunt() {
        bigRobotAnimator.SetTrigger("Taunt");
    }
    public void BigRobotHurt() {
        bigRobotAnimator.SetTrigger("Hurt");
    }
    public void BigRobotPoint() {
        bigRobotAnimator.SetTrigger("Point");
    }
    public void BigRobotPickUp() {
        bigRobotAnimator.SetTrigger("PickUp");
    }
    public void BigRobotLeftPunch() {
        bigRobotAnimator.SetTrigger("LeftPunch");
    }


    public void CompanionShield() {
        companionAnimator.SetTrigger("Shield");
    }

    public void CompanionIdle() {
        companionAnimator.SetTrigger("Idle");
    }

    public void CompanionSlam() {
        companionAnimator.SetTrigger("Slam");
    }

    public void CompanionExclamation()
    {
        companionAnimator.SetTrigger("Exclamation");
    }

    public void SmallRobotMeleeHurt() {
        foreach (Animator a in smallRobotsMelee)
            StartCoroutine(RobotHurt(a));
    }

    protected IEnumerator RobotHurt(Animator anim) {
        yield return new WaitForSeconds(Random.Range(0, 0.1f));
        anim.SetTrigger("Hurt");
    }

    public void SmallRobotMeleeSurprised() {
        foreach (Animator a in smallRobotsMelee)
            StartCoroutine(RobotSurprised(a));
    }

    protected IEnumerator RobotSurprised(Animator anim) {
        yield return new WaitForSeconds(Random.Range(0, 0.3f));
        if (anim.GetComponent<UnitSpeech>())
            anim.GetComponent<UnitSpeech>().Speak(Mood.Surprised);
    }


    public void SmallRobotMeleeIdle() {
        foreach (Animator a in smallRobotsMelee)
            StartCoroutine(RobotIdle(a));
    }

    protected IEnumerator RobotIdle(Animator anim) {
        yield return new WaitForSeconds(Random.Range(0, 1));
        anim.SetTrigger("Idle");
    }

    public void SmallRobotMeleeAttack() {
        System.Random r = new System.Random();
        foreach (Animator a in smallRobotsMelee) {
            StartCoroutine(RobotAttack(a, (float)r.NextDouble()));
        }
    }

    private IEnumerator RobotAttack(Animator anim, float delay) {
        yield return new WaitForSeconds(delay);
        anim.SetTrigger("Attack");

    }

    public void SmallRobotMeleeTaunt() {
        System.Random r = new System.Random();
        foreach (Animator a in smallRobotsMelee)
            StartCoroutine(RobotTaunt(a, (float)r.NextDouble()));
    }

    protected IEnumerator RobotTaunt(Animator anim, float delay) {
        yield return new WaitForSeconds(Random.Range(0, 1));
        anim.SetTrigger("Taunt");
    }

    public void SmallRobotMeleeLaugh() {
        foreach (Animator a in smallRobotsMelee)
            StartCoroutine(RobotLaugh(a));
    }

    protected IEnumerator RobotLaugh(Animator anim) {
        yield return new WaitForSeconds(Random.Range(0, 1));
        anim.SetTrigger("Laugh");
    }

    public void SmallRobotMeleeWalk() {
        foreach (Animator a in smallRobotsMelee)
            a.SetTrigger("Walk");
    }

    public void SmallRobotRangeIdle() {
        foreach (Animator a in smallRobotsRange)
            StartCoroutine(RobotIdle(a));
    }

    public void SmallRobotRangeTaunt() {
        System.Random r = new System.Random();
        foreach (Animator a in smallRobotsRange)
            StartCoroutine(RobotTaunt(a, (float)r.NextDouble()));
    }

    public void SmallRobotRangeWalk() {
        foreach (Animator a in smallRobotsRange)
            a.SetTrigger("Walk");
    }

    public void StopCinematic() {
        GetComponent<Animator>().Stop();
        GetComponent<Animator>().enabled = false;
    }

}

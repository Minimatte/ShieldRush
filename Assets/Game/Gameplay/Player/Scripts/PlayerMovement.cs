using UnityEngine;


[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerAttack))]
public class PlayerMovement : MonoBehaviour {
    public static bool PlayerActive = true;

    private MovementProperties movementProperties;
    private RollProperties rollProperties;
    private Player playerProperties;
    private ShieldProperties playershieldProperties;

    public bool canMove { get { return !rollProperties.isRolling && movementProperties.canMove && playerProperties.stunnedTime <= 0; } }
    private Animator anim;
    private Quaternion lookRotation;

    void Awake() {

        playerProperties = GetComponent<Player>();
        rollProperties = playerProperties.rollProperties;
        movementProperties = playerProperties.movementProperties;
        playershieldProperties = playerProperties.shieldProperties;
        anim = playerProperties.unitMesh.GetComponent<Animator>();
    }

    void UpdateRotation() {
        if (canMove) {

            Vector3 direction = (new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"))).normalized;

            direction = Quaternion.Euler(0, Camera.main.transform.localRotation.eulerAngles.y, 0) * direction;
            lookRotation = Quaternion.LookRotation(direction);
            playerProperties.unitMesh.rotation = Quaternion.Slerp(playerProperties.unitMesh.rotation, lookRotation, Time.deltaTime * movementProperties.rotationSpeed);

        }
    }

    void Update() {
        if (!PlayerActive)
            return;
        if (GameController.isPaused)
            return;
        Vector3 dxy;
        if (Input.GetJoystickNames().Length > 0 && Input.GetJoystickNames()[0] != "") {

            dxy = new Vector3(Input.GetAxis("Horizontal") * movementProperties.movementSpeedBase * movementProperties.movementSpeedMultiplier, 0.0f, Input.GetAxis("Vertical") * movementProperties.movementSpeedBase * movementProperties.movementSpeedMultiplier);
            if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && (!playershieldProperties.shieldActive || !playershieldProperties.isAlive)) {
                UpdateRotation();
            }
        } else {
            dxy = new Vector3(Input.GetAxisRaw("Horizontal") * movementProperties.movementSpeedBase * movementProperties.movementSpeedMultiplier, 0.0f, Input.GetAxisRaw("Vertical") * movementProperties.movementSpeedBase * movementProperties.movementSpeedMultiplier);
            if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && (!playershieldProperties.shieldActive || !playershieldProperties.isAlive)) {
                UpdateRotation();
            }
        }

        /*
                dxy = Quaternion.Euler(0, Camera.main.transform.localRotation.eulerAngles.y, 0) * dxy;
                if (canMove) {
                    transform.Translate(Vector3.ClampMagnitude(dxy, movementProperties.movementSpeedBase * movementProperties.movementSpeedMultiplier) * Time.deltaTime);
                }
                    */
        dxy = Quaternion.Euler(0, Camera.main.transform.localRotation.eulerAngles.y, 0) * dxy;



        if (canMove) {
            GetComponent<CharacterController>().SimpleMove(Vector3.ClampMagnitude(dxy, movementProperties.movementSpeedBase * movementProperties.movementSpeedMultiplier));

            float targetSpeed = Mathf.Lerp(anim.GetFloat("Speed"), playerProperties.GetComponent<CharacterController>().velocity.normalized.magnitude, Time.deltaTime * 10);
            anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")));

        } else {
            anim.SetFloat("Speed", 0);
        }
    }


}

using UnityEngine;
using System.Collections;

public class Companion : MonoBehaviour {
    public Player player;
    [Range(0, 100)]
    public float speed;
    public GameObject EMPProjectile;
    private bool canUseEMP = false;

    private float boredCounter = 0;
    private Vector3 lastPos;

    private UnitSpeech speech;

    public float side = 1;

    public void SetupEMP() {
        canUseEMP = true;
        player.GetComponent<ShieldBash>().canUse = false;
        GetComponent<UnitSpeech>().Speak(Mood.Happy);
    }

    private void UseEMP() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        float dist = 0;

        if (playerPlane.Raycast(ray, out dist)) {

            Vector3 thehit = ray.GetPoint(dist);

            transform.LookAt(new Vector3(thehit.x, transform.position.y, thehit.z), Vector3.up);
        }


        Player playerProperties = player;
        GameObject projectile = (GameObject)Instantiate(EMPProjectile, transform.position + transform.forward, Quaternion.Euler(transform.eulerAngles));
        projectile.GetComponent<EMPProjectile>().Initialize(transform.forward, playerProperties.attackProperties, player.gameObject);
        projectile.gameObject.layer = player.gameObject.layer;

        StartCoroutine(EMPEnd());
    }

    IEnumerator EMPEnd() {
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<ShieldBash>().canUse = true;

    }

    void Start() {
        player.companion = this;
        if (transform.parent != null)
            transform.SetParent(null);
        lastPos = transform.position;
        speech = GetComponent<UnitSpeech>();
    }

    void Update() {
        if (!PlayerMovement.PlayerActive)
            return;
        if (canUseEMP) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane playerPlane = new Plane(Vector3.up, transform.position);

            float dist = 0;

            if (playerPlane.Raycast(ray, out dist)) {

                Vector3 thehit = ray.GetPoint(dist);

                Debug.DrawLine(transform.position, thehit);
                transform.LookAt(thehit);
            }
        }

        if (canUseEMP && Input.GetButtonDown("MeleeAttack")) {
            UseEMP();
            canUseEMP = false;
        }

        if (player != null) {

            if (player.shieldProperties.shieldActive) {


                Vector3 targetLoc = player.unitMesh.position;
                targetLoc += player.unitMesh.forward + player.unitMesh.up;

                transform.position = Vector3.Lerp(transform.position, targetLoc, Time.deltaTime * speed * 3);
                if (!canUseEMP)
                    transform.rotation = Quaternion.Lerp(transform.rotation, player.unitMesh.rotation, 10 * Time.deltaTime);
            } else {

                Vector3 targetLoc = player.unitMesh.position;

                targetLoc += player.unitMesh.right * side * 2 + player.unitMesh.up * 2;
                targetLoc.y += Mathf.Sin(Time.realtimeSinceStartup * 4) / 3; // 4 is how fast it is, 3 is how far up and dow it goes

                transform.position = Vector3.Lerp(transform.position, targetLoc, Time.deltaTime * speed);
                if (!canUseEMP)
                    transform.rotation = Quaternion.Lerp(transform.rotation, player.unitMesh.rotation, 8f * Time.deltaTime);
            }
        } else {
            Destroy(gameObject);
        }
    }

    void LateUpdate() {

        if (transform.position.x == lastPos.x && transform.position.z == lastPos.z && PlayerMovement.PlayerActive)
            boredCounter += Time.deltaTime;
        else
            boredCounter = 0;

        if (boredCounter >= 15 && PlayerMovement.PlayerActive) {
            GetComponent<UnitSpeech>().Speak(Mood.Bored);
            boredCounter = 0;
        }

        lastPos = transform.position;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Helpful") {
            speech.Speak(Mood.Helpful);
            GetComponent<Animator>().SetTrigger("Exclamation");
        }
    }

}

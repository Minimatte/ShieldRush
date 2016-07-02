using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraMovement : MonoBehaviour {

    public GameObject player; //The offset of the camera to centrate the player in the X axis 
    public float offsetX = 0; //The offset of the camera to centrate the player in the Z axis 
    public float offsetY = 0;
    public float offsetZ = 0;

    //The maximum distance permited to the camera to be far from the player, its used to make a smooth movement 
    public float leash = 2; //The velocity of your player, used to determine que speed of the camera 
    public float playerVelocity = 10;

    public float distance = 108;

    private float movementX;
    private float movementY;
    private float movementZ;

    private float shake = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    internal float shakeAmount = 0.1f;
    internal float decreaseFactor = 1.0f;

    public bool showDebug = false;

 
    public float startCamSize;
    
    public float camSize;

    void Start() {
        camSize = distance;
        startCamSize = camSize;
        if (player == null) {
            GameObject[] playerTags = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject go in playerTags) {
                if (go.GetComponent<Player>()) {
                    player = go;
                    break;
                }
            }
        }
    }
    public float lerpSpeed = 2;
    // Update is called once per frame 
    void LateUpdate() {
        Camera cam = GetComponent<Camera>();
        distance = Mathf.Lerp(distance, camSize, Time.deltaTime * lerpSpeed);
        if (player) {
            movementX = -(transform.forward.x * distance) + (player.transform.position.x + offsetX - transform.position.x) / leash;
            movementY = -(transform.forward.y * distance) + (player.transform.position.y + offsetY - transform.position.y) / leash;
            movementZ = -(transform.forward.z * distance) + (player.transform.position.z + offsetZ - transform.position.z) / leash;
            //offsetZ = -offsetY / 3;
            transform.position += new Vector3((movementX * playerVelocity * Time.deltaTime), (movementY * playerVelocity * Time.deltaTime), (movementZ * playerVelocity * Time.deltaTime));
            //if (Application.isPlaying)
            //    CheckForObject();
        }

        if (shake > 0 && !GameController.isPaused) {
            transform.localPosition = transform.localPosition + new Vector3(Random.insideUnitSphere.x * shakeAmount, 0, Random.insideUnitSphere.z * shakeAmount);
            shake -= Time.deltaTime * decreaseFactor;

        } else {
            shake = 0;
        }

    }

    public void ShakeCamera(float time, float force) {
        shake = time;
        shakeAmount = force;
    }


    public void CheckForObject() {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hits;
        float posDistance = Vector3.Distance(player.transform.position, transform.position) * 0.95f;

        hits = Physics.RaycastAll(ray, posDistance);
        if (showDebug) {
            Debug.DrawLine(transform.position, transform.position + transform.forward * posDistance, (hits.Length > 0) ? Color.red : Color.white);
        }

        foreach (RaycastHit hit in hits) {
            if (!hit.collider.CompareTag("IgnoreTransparency"))
                if (hit.collider.GetComponent<Renderer>()) {
                    Transparency t = hit.collider.gameObject.GetComponent<Transparency>();
                    if (t == null)
                        t = hit.collider.gameObject.AddComponent<Transparency>();
                    t.BeTransparent();
                }
        }
    }

}

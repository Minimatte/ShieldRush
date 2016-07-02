using UnityEngine;
using System.Collections;

public class Train : MonoBehaviour {
    public float stoppingDistance = 5f;
    public bool move = false;
    public Transform targetLocation;

    private bool arrived = false;
    private Vector3 startLoc;

    private float actualStoppingDistance;
    private float actualSpeed;

    public float speed = 2;
    public float leaveDelay = 0;
    void Awake() {
        actualSpeed = speed;
        actualStoppingDistance = stoppingDistance;
        startLoc = transform.position;
    }

    void Update() {
        if (move && targetLocation != null)
            if (!arrived) {
                transform.position = Vector3.Lerp(transform.position, targetLocation.position, Time.deltaTime * actualSpeed);
                if (Vector3.Distance(transform.position, targetLocation.position) < actualStoppingDistance) {
                    RandomizeBuffert();
                    StartCoroutine(WaitForDelay());
                }
            } else {
                if (Vector3.Distance(transform.position, startLoc) < actualStoppingDistance) {
                    RandomizeBuffert();
                    StartCoroutine(WaitForDelay());
                }
                transform.position = Vector3.Lerp(transform.position, startLoc, Time.deltaTime * actualSpeed);
            }
    }

    void RandomizeBuffert() {
        actualStoppingDistance = stoppingDistance + Random.Range(stoppingDistance * -0.3f, stoppingDistance * 0.3f);
        actualSpeed = speed + Random.Range(speed * -0.3f, speed * 0.3f);
    }

    private IEnumerator WaitForDelay() {
        yield return new WaitForSeconds(leaveDelay);
        arrived = !arrived;
    }
}

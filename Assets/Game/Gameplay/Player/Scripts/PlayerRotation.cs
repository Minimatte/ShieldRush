using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerRotation : MonoBehaviour {

    float rotationY = 0F;

    private Quaternion lookRotation;
    private Vector3 direction;

    public LayerMask mouseCollision;

    private Transform rotateBody;

    void Start() {
        rotateBody = GetComponent<Player>().unitMesh;
    }

    public void LookAtMouse() {
        if (Options.UseController) {
            float x = Input.GetAxis("Vertical");
            float y = Input.GetAxis("Horizontal");
            float aim_angle = 0.0f;

            float R_analog_threshold = 0.20f;

            if (Mathf.Abs(x) < R_analog_threshold) { x = 0.0f; }

            if (Mathf.Abs(y) < R_analog_threshold) { y = 0.0f; }

            if (x != 0.0f || y != 0.0f) {

                aim_angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

                rotateBody.transform.rotation = Quaternion.AngleAxis(aim_angle + Camera.main.transform.eulerAngles.y, Vector3.up);
            }

        } else {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane playerPlane = new Plane(Vector3.up, transform.position);

            float dist = 0;

            if (playerPlane.Raycast(ray, out dist)) {

                Vector3 thehit = ray.GetPoint(dist);

                rotateBody.LookAt(new Vector3(thehit.x, rotateBody.position.y, thehit.z), Vector3.up);
            }
        }
    }
}

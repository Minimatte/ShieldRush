using UnityEngine;
using System.Collections;
using System;

public class ChargeAttack : Attack {

    public GameObject particlePrefab;
    private GameObject particleInstance;

    public RollProperties rollProperties;

    Enemy enemy;

    void Start() {
        enemy = GetComponent<Enemy>();
        //mesh = GetComponent<Enemy>().unitMesh;
    }

    void roll(float force, Vector3 direction) {
        StartCoroutine(waitForRoll(force, direction));
    }


    public IEnumerator waitForRoll(float force, Vector3 direction) {

        NavMeshAgent nma = GetComponent<NavMeshAgent>();

        float angularSpeedTemp = nma.angularSpeed;
        nma.angularSpeed = 0;


        mesh.rotation = Quaternion.LookRotation(direction);

        float rollDistance = force;

        enemy.movementProperties.canRotate = false;
        rollProperties.canRoll = false;
        rollProperties.isRolling = true;
        Vector3 targetPos = direction;
        for (float i = 1; i < rollDistance; i += 0.3f)
            if (Physics.Raycast(transform.position + direction * i, -Vector3.up, 1f, rollProperties.rollDetectionLayers)
                && !Physics.Raycast(transform.position + direction * (i - 1), direction, 1f, rollProperties.rollDetectionLayers)) {
                targetPos = transform.position + direction * i;
                Debug.DrawLine(transform.position + direction * i, (transform.position + direction * i) + transform.up * -1f);
            } else {
                break;
            }


        if (targetPos.magnitude > 1) { // spawn particle if distance > 1
    
            Vector3 rot = enemy.unitMesh.rotation.eulerAngles;
            Destroy((GameObject)Instantiate(particlePrefab, transform.position + Vector3.up * 2.5f, Quaternion.Euler(new Vector3(90, rot.y + 90, 0))), 2f);
            //particleInstance.transform.SetParent(gameObject.transform, true);

        }

        float counter = 0;

        Vector3 start = transform.position;
        Vector3 lastPos = transform.position;

        int tries = 0;
        if (targetPos != direction)
            while (transform.position != targetPos && tries < 50) {
                if (GameController.isPaused) {
                    yield return new WaitForSeconds(0.01f);
                } else {

                    findLoc(mesh.position + mesh.forward * 2, enemy.attackProperties.damage / 5);

                    tries++;

                    counter += Time.deltaTime;
                    //transform.Translate(-mesh.up * Time.deltaTime);

                    transform.position = Vector3.Lerp(start, targetPos, rollProperties.rollSpeed.Evaluate(counter));
                    if (lastPos == transform.position) {
                        transform.position = targetPos;
                        break;
                    }

                    lastPos = transform.position;

                    yield return 0;


                    if (Vector3.Distance(transform.position, targetPos) < 1)
                        if (particleInstance != null) {
                            particleInstance.GetComponent<ParticleSystem>().Stop();
                            particleInstance.transform.SetParent(null);
                            Destroy(particleInstance, 1);
                        }
                }
            }

        nma.angularSpeed = angularSpeedTemp;
        enemy.movementProperties.canRotate = true;
        rollProperties.canRoll = true;
        rollProperties.isRolling = false;
        enemy.attackProperties.canAttack = true;
        yield return null;
    }



    private void findLoc(Vector3 location, float damage) {

        if (GetComponent<EnemyAI>()) {

            Vector3 lookAtLocation = location;
            lookAtLocation.y = transform.position.y;
            mesh.LookAt(lookAtLocation);
        }

        FindAndDealDamage(location, damage);

    }

    public override void UseAttack(Vector3 location) {
        roll(rollProperties.rollDistance, transform.forward);
    }
}

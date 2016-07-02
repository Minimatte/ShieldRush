using UnityEngine;
using System.Collections;

public class ShockwaveSize : MonoBehaviour {

    ParticleSystem psystem;


    float radius;
    void Awake() {
        psystem = GetComponent<ParticleSystem>();
        radius = psystem.shape.radius;
    }

    void Start() {

    }

    void Update() {
        var x = psystem.shape;
        x.radius = Mathf.MoveTowards(x.radius, radius * 10, 30 * Time.deltaTime);

        float value = 1f - (x.radius / (radius * 10));

        psystem.startSpeed = value;

        if (x.radius == radius * 10) {
       
            psystem.Stop();
        }
    }
}

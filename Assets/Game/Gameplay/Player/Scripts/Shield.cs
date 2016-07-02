using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shield : MonoBehaviour {

    private Dictionary<Transform, Vector3> startSize;
    [SerializeField]
    ParticleSystem hitParticle;
    public Player player;
    void Awake() {
        startSize = new Dictionary<Transform, Vector3>();
        foreach (Transform t in transform) {
            startSize.Add(t, t.transform.localScale);
        }
    }

    void Update() {
        bool shieldActive = player.shieldProperties.shieldActive;

        if (shieldActive) {
            foreach (Transform t in startSize.Keys) {
                t.localScale = Vector3.Lerp(t.localScale, startSize[t] * 1.5f, 10f * Time.deltaTime);
            }
        } else {
            ResetSize();
        }

    }

    public void ResetSize() {
        foreach (Transform t in startSize.Keys) {
            t.localScale = startSize[t];
        }
        
    }
}

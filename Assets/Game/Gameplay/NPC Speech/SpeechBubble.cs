using UnityEngine;
using System.Collections;

public class SpeechBubble : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer image;

    public float lifeTime = 3;

    void Awake() {
        if (lifeTime == 0)
            lifeTime = int.MaxValue;
        Destroy(gameObject, lifeTime);
    }

    public void SetImage(Sprite image) {
        this.image.sprite = image;
    }

    void Update() {
        transform.rotation = Quaternion.LookRotation(-Camera.main.transform.up, Vector3.up);
    }
}

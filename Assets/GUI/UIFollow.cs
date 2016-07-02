using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIFollow : MonoBehaviour {


    public RectTransform followThis;
    private Image image;
    private Color startColor;
    void Awake() {
        image = GetComponent<Image>();
        startColor = image.color;

    }

    void Update() {
        transform.position = Vector3.Lerp(transform.position, followThis.position, 6f * Time.deltaTime);
        //print(image.color.ToString());
        image.color = Color.Lerp(image.color, startColor, Time.deltaTime);
    }

    void Start() {
        image.color = new Color(startColor.r, startColor.g, startColor.b, 0);
    }
}

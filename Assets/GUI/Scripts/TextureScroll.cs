using UnityEngine;
using System.Collections;

public class TextureScroll : MonoBehaviour
{
    public float scrollSpeed = 0.5F;
    public Renderer rend;
    void Start()
    {
       rend = GetComponent<Renderer>();
    }
    void Update()
    {
        Vector2 offset = new Vector2 (0, Time.time * scrollSpeed);
        rend.material.mainTextureOffset = offset;
        //float offset = Time.time * scrollSpeed;
        //rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
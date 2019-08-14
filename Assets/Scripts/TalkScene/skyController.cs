using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyController : MonoBehaviour
{
    private new Renderer renderer;
    public float speed;
    public float offset;

    void Start () {

        renderer = GetComponent<Renderer>(); 

    }

    void Update () {
        offset = Time.time * speed;
        renderer.material.SetTextureOffset("_MainTex",new Vector2(offset,0));
    }
}

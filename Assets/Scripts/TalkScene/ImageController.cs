using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Sprite[] birdImages = new Sprite[6];
    public SpriteRenderer birdImage;

    // Start is called before the first frame update
    void Start()
    {
        birdImage = GetComponent<SpriteRenderer>();
        birdImage.sprite = birdImages[0];

    }

    // Update is called once per frame
    void Update()
    {
    }
}

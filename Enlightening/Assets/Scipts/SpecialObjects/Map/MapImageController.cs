using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapImageController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color32[] pixels = new Color32[200 * 200];
    System.Random random = new System.Random();

    PlayerController playerController;
    void Start()
    {
        transform.localScale = new Vector3(50f, 50f, 0);
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // for (int i = 0; i < pixels.Length; i++)
        // {
        //     pixels[i] = new Color32(0, 0, 0, 255);
        // }

        // spriteRenderer.sprite.texture.SetPixels32(pixels);
        // spriteRenderer.sprite.texture.Apply();

    }


    void Update()
    {
        // Debug.Log((int)playerController.transform.position.y * 200 + (int)playerController.transform.position.x);
        // pixels[(int)playerController.transform.position.y * 200 + (int)playerController.transform.position.x] = new Color32(255, 255, 255, 255);

        // spriteRenderer.sprite.texture.SetPixels32(pixels);
        // spriteRenderer.sprite.texture.Apply();

    }
}
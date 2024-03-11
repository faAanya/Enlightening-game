using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTexture : MonoBehaviour
{
    private Texture2D mapTexture;

    private PlayerController playerController;
    Color32[] pixels = new Color32[32 * 32];
    void Start()
    {
        mapTexture = new Texture2D(32, 32);
        mapTexture.wrapMode = TextureWrapMode.Clamp;
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = new Color32(0, 0, 0, 100);
        }
        mapTexture.SetPixels32(pixels);
        mapTexture.Apply();

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private int GetIndex(int x, int y)
    {

        return (2 * (int)playerController.transform.position.x + 1) * (y + (int)playerController.transform.position.y) + (x + (int)playerController.transform.position.x);

    }

    void Update()
    {

        for (int i = (int)playerController.transform.position.y; i <= (int)playerController.transform.position.y; i++)
        {
            for (int j = (int)-playerController.transform.position.x; j <= playerController.transform.position.x; j++)
            {
                pixels[GetIndex(i, j)] = new Color32(255, 255, 255, 100);
            }

        }
        mapTexture.SetPixels32(pixels);
        mapTexture.Apply();
    }


    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), mapTexture
);
    }
    // Update is called once per frame
}

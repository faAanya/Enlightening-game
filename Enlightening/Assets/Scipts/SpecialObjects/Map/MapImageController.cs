using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapImageController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    PlayerController playerController;
    void Start()
    {
        transform.localScale = new Vector3(50f, 50f, 0);
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {


    }
}
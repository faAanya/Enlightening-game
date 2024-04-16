using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LookAroundCameraController : MonoBehaviour
{
    [SerializeField] Camera cam;
    private Transform player;
    private PlayerController playerController;
    [SerializeField] private float threshold;


    [Header("BoundsControll")]
    private Bounds cameraBounds;
    private Vector3 targetPos = new Vector3();

    void Start()
    {

        var height = cam.orthographicSize;
        var width = height * cam.aspect;



        var minX = SetWorldBounds.worldBounds.min.x + width;
        var maxX = SetWorldBounds.worldBounds.extents.x - width;


        var minY = SetWorldBounds.worldBounds.min.y + height;
        var maxY = SetWorldBounds.worldBounds.extents.y - height;

        cameraBounds = new Bounds();
        cameraBounds.SetMinMax(new Vector3(minX, maxX, 0), new Vector3(minY, maxY, 0));



        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(playerController.InputHandler.inputPosition);
        Vector3 targetPos = (player.transform.position + mousePos) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, -threshold + player.transform.position.x, threshold + player.transform.position.x);

        targetPos.y = Mathf.Clamp(targetPos.y, -threshold + player.transform.position.y, threshold + player.transform.position.y);

        this.transform.position = targetPos;
    }

    void LateUpdate()
    {
        targetPos = GetCameraBounds();
        transform.position = targetPos;
    }

    private Vector3 GetCameraBounds()
    {
        return new Vector3(
            Math.Clamp(targetPos.x, cameraBounds.min.x, cameraBounds.max.x),
            Math.Clamp(targetPos.y, cameraBounds.min.y, cameraBounds.max.y),
            transform.position.z
        );


    }
}

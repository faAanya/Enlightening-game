using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAroundCameraController : MonoBehaviour
{
    [SerializeField] Camera cam;
    private Transform player;
    private PlayerController playerController;
    [SerializeField] private float threshold;
    void Start()
    {
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
}

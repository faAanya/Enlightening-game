using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathUI : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject deathUI;
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        deathUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.health <= 0)
        {
            PlayerDie();
        }
    }

    public void PlayerDie()
    {
        deathUI.SetActive(true);
        Time.timeScale = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShooterLogic : MonoBehaviour, IAttack
{
    public WeaponDataSO weaponData;
    private PlayerController playerController;

    public Vector3 mousePos;

    private Camera mainCam;

    public bool canAttack = true;

    public GameObject bullet;

    public float interval;
    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    private void Update()
    {
        Attack();
    }

    public void Attack()
    {

        mousePos = mainCam.ScreenToWorldPoint(playerController.InputHandler.inputPosition);

        //Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot + 90f);
        if (canAttack)
        {
            StartCoroutine(Shoot(interval, bullet));
        }
       
        //aim.transform.position = new Vector3(weaponData.range * Mathf.Cos(((rot + 180) * Mathf.PI) / 180) + transform.position.x, weaponData.range * Mathf.Sin((rot + 180) * Mathf.PI / 180) + transform.position.y, 0);
    }
    private IEnumerator Shoot(float interval, GameObject bullet)
    {
        canAttack = false;
        yield return new WaitForSeconds(interval);
        canAttack = true;

        GameObject newBullet = Instantiate(bullet, playerController.transform.position, Quaternion.identity);
      
        StartCoroutine(Shoot(interval, bullet));
    }
}

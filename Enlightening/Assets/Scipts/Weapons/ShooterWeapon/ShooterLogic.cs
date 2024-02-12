using System.Collections;
using UnityEngine;


public class ShooterLogic : MonoBehaviour, IAttack
{
    private PlayerController playerController;

    [HideInInspector]
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
        Rotate();
    }

    public void Rotate()
    {

        mousePos = mainCam.ScreenToWorldPoint(playerController.InputHandler.inputPosition);

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

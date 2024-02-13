using System.Collections;
using UnityEngine;


public class TeslaLaserWeaponLogic : MonoBehaviour, IAttack
{
    [HideInInspector]
    public PlayerController playerController;
    private Vector3 mousePos;

    private Camera mainCam;

    private bool canAttack = true;


    [Header("WeaponParametres")]
   public GameObject blinker;


    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        Rotate();
        if (canAttack) { StartCoroutine(Blink()); }
    }

    public void Rotate() 
    {

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(playerController.InputHandler.inputPosition);
       
        Vector3 rotation = transform.position - mousePos;

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180f);
        //transform.position = new Vector3(weaponData.range * Mathf.Cos(((rot + 180) * Mathf.PI) / 180) + transform.position.x, weaponData.range * Mathf.Sin((rot + 180) * Mathf.PI / 180) + transform.position.y, 0);
    }

    public IEnumerator Blink()
    {
        playerController.InputHandler.canUseInputs = false;
        yield return new WaitForSeconds(blinker.GetComponent<Weapon>().duration);
        canAttack = false;
        blinker.gameObject.SetActive(false);
        yield return new WaitForSeconds(blinker.GetComponent<Weapon>().coolDown);
        blinker.gameObject.SetActive(true);
        canAttack = true;
        playerController.InputHandler.canUseInputs = true;
    }


}

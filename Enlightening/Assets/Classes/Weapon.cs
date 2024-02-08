using System.Collections;
using UnityEngine;


public class Weapon : MonoBehaviour, IAttack
{
    public WeaponDataSO weaponData;
    [HideInInspector]
    public PlayerController player;
    public Vector3 mousePos;

    public Transform center;
    public Transform hitPoint;

    private Camera mainCam;

    public bool canAttack = true;

   public GameObject weapon;
    public GameObject endPoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        Attack();
        if (canAttack) { StartCoroutine(Shot()); }
        Debug.Log(player.InputHandler.canUseInputs);
    }

    public void Attack() 
    {

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(player.InputHandler.inputPosition);
        Vector3 direction = mousePos - endPoint.transform.position;
        Vector3 rotation = transform.position - mousePos;

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        endPoint.transform.position = new Vector3(weaponData.range * Mathf.Cos(((rot + 180) * Mathf.PI) / 180) + transform.position.x, weaponData.range * Mathf.Sin((rot + 180) * Mathf.PI / 180) + transform.position.y, 0);

    }

    public IEnumerator Shot()
    {
        player.InputHandler.canUseInputs = false;
        yield return new WaitForSeconds(weaponData.duration);
        canAttack = false;
        weapon.gameObject.SetActive(false);
        yield return new WaitForSeconds(weaponData.coolDown);
        weapon.gameObject.SetActive(true);
        canAttack = true;
        player.InputHandler.canUseInputs = true;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(center.transform.position, hitPoint.transform.position);
    }
}

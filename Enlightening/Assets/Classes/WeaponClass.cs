using UnityEngine;

public class WeaponClass : MonoBehaviour
{
    public string Name;
    public float damage;
    public float duration;
    public float coolDown;

    public float size;

    public int number;

    public bool canAttack = true;

    protected PlayerController playerController;
    protected Camera mainCamera;

    protected Vector3 mousePosition;

    protected Weapon weapon;


    public GameObject projectile;

    public bool isAvaliable;

    public virtual void Start()
    {
        this.playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        this.mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        projectile.GetComponent<Weapon>().damage = this.damage;

    }

    public virtual void Update()
    {
        this.mousePosition = mainCamera.ScreenToWorldPoint(playerController.InputHandler.inputPosition);
    }


    public void Rotate(GameObject gameObject, Vector3 mousePos)
    {

        Vector3 rotation = transform.position - mousePos;

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        gameObject.transform.rotation = Quaternion.Euler(0, 0, rot + 90f);
    }

    public void Rotate(GameObject[] gameObjects, Vector3 mousePos)
    {
        Vector3 rotation = transform.position - mousePos;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        for (int i = 0, j = 0; i < gameObjects.Length && j < 360; i++, j += 360 / gameObjects.Length)
        {
            gameObjects[i].transform.rotation = Quaternion.Euler(0, 0, rot);
        }

    }

}

using UnityEngine;

public class Bullets : MonoBehaviour
{
    public Vector3 mousePos;
    private Camera mainCam;
    private PlayerController playerController;
    public PlayerDataSO playerData;
    public Rigidbody2D rb;
    public float force;

    public WeaponDataSO weaponData;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(playerController.InputHandler.inputPosition);

        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot + 90f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x >= weaponData.range || gameObject.transform.position.y >= weaponData.range 
           || gameObject.transform.position.x <= -weaponData.range || gameObject.transform.position.y <= -weaponData.range)
        {
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class NearProjectilesSpawner : MonoBehaviour
{
    private GameObject[] projectiles;
    public GameObject projectile;
    private Weapon weapon;
    private bool canRotate = true;

    public AnimationCurve curve;
    void Start()
    {

        weapon = projectile.GetComponent<Weapon>();
        Debug.Log("Meow");
        projectiles = new GameObject[weapon.amount];
        for (int i = 0; i < projectiles.Length; i++)
        {
            projectiles[i] = projectile;
        }

        for (int i = 0, j = 0; i < projectiles.Length && j < 360; i++, j += 360 / projectiles.Length)
        {

            Vector3 pos = new Vector3(weapon.range * Mathf.Cos((j * Mathf.PI) / 180) + transform.position.x, weapon.range * Mathf.Sin((j * Mathf.PI) / 180) + transform.position.y, 0);
           GameObject prj = Instantiate(projectiles[i], pos, Quaternion.identity);
             prj.transform.parent = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            StartCoroutine(Rota());
        }
       
    }
    public IEnumerator Rota()
    {    canRotate = false;
        float timer = 0;
        for (int i = 0; i < 91; i++)
        {
             timer += Time.deltaTime;
            transform.Rotate(0, 0, 1);
            yield return new WaitForSeconds(curve.Evaluate(timer));
        }
   
        yield return new WaitForSeconds(2f);
        canRotate = true; 


    }
}

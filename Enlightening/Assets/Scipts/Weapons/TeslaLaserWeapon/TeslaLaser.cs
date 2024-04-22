using System.Collections;
using UnityEngine;


public class TeslaLaserWeaponLogic : WeaponClass
{

    public GameObject[] projectiles;
    public int startNumber;
    public override void Start()
    {
        base.Start();
        startNumber = number;
        projectiles = new GameObject[number];
        for (int i = 0, j = 0; i < projectiles.Length && j < 360; i++, j += 360 / projectiles.Length)
        {
            projectiles[i] = Instantiate(projectile, transform);
            projectiles[i].transform.rotation = Quaternion.Euler(0, 0, j + 90f);
            projectiles[i].transform.SetParent(gameObject.transform);
        }
    }

    public override void Update()
    {
        base.Update();
        if (number != startNumber)
        {

            projectiles = new GameObject[number];

            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(gameObject.transform.GetChild(i).gameObject);
            }

            for (int i = 0, j = 0; i < number && j < 360; i++, j += 360 / projectiles.Length)
            {
                projectiles[i] = Instantiate(projectile, transform);
                projectiles[i].transform.rotation = Quaternion.Euler(0, 0, j + 90f);
                projectiles[i].transform.SetParent(gameObject.transform);
            }
            startNumber = number;
        }

        Rotate(gameObject, mousePosition);
        if (canAttack)
        {

            StartCoroutine(Blink());
        }

    }
    public IEnumerator Blink()
    {

        canAttack = false;
        yield return new WaitForSeconds(duration);

        for (int i = 0, j = 0; i < projectiles.Length && j < 360; i++, j += 360 / projectiles.Length)
        {
            projectiles[i].gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(coolDown);
        for (int i = 0, j = 0; i < projectiles.Length && j < 360; i++, j += 360 / projectiles.Length)
        {
            projectiles[i].gameObject.SetActive(true);
        }

        canAttack = true;
    }


}

using System.Collections;
using UnityEngine;


public class TeslaLaserWeaponLogic : WeaponClass
{
   
   public GameObject[] projectiles;

    public override void Start()
    {
       base.Start();
      
        projectiles = new GameObject[number];
        for (int i = 0, j = 0; i < projectiles.Length && j < 360; i++, j += 360 / projectiles.Length)
        {
          
            projectiles[i] = Instantiate(projectile, transform.position, Quaternion.Euler(0,0, j + 90f));
            projectiles[i].transform.SetParent(gameObject.transform);
            
        }
    }

    public override void Update()
    {
        base.Update();
        Rotate(gameObject, mousePosition);
        if (canAttack) {
           
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

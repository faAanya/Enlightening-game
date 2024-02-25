using System.Collections;
using UnityEngine;


public class ShooterLogic : WeaponClass
{
    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        Rotate(gameObject, mousePosition);
         if (canAttack)
        {
            StartCoroutine(Shoot(coolDown, projectile));
        }
    }

    private IEnumerator Shoot(float interval, GameObject projectile)
    {
        canAttack = false;
        yield return new WaitForSeconds(interval);
        canAttack = true;

        GameObject newprojectile = Instantiate(projectile, playerController.transform.position, Quaternion.identity);
      
        StartCoroutine(Shoot(interval, projectile));
    }
}

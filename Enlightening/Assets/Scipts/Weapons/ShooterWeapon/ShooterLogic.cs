using System.Collections;
using UnityEngine;


public class ShooterLogic : WeaponClass
{
    public override void Start()
    {
        base.Start();

        InvokeRepeating("SpawnBullet", 0f, coolDown);


    }
    public override void Update()
    {
        Rotate(gameObject, mousePosition);

        canAttack = false;
    }

    public void SpawnBullet()
    {
        Instantiate(projectile, playerController.transform.position, Quaternion.identity);

    }


}

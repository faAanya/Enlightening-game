using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class NearProjectilesSpawner : WeaponClass
{
    private GameObject[] projectiles;
    public AnimationCurve curve;
    public override void Start()
    {

        base.Start();


        projectiles = new GameObject[number];
        for (int i = 0; i < projectiles.Length; i++)
        {
            projectiles[i] = projectile;
        }

        for (int i = 0, j = 0; i < projectiles.Length && j < 360; i++, j += 360 / projectiles.Length)
        {

            Vector3 pos = new Vector3(size * Mathf.Cos(j * Mathf.PI / 180) + transform.position.x, size * Mathf.Sin(j * Mathf.PI / 180) + transform.position.y, 0);
            GameObject prj = Instantiate(projectiles[i], pos, Quaternion.identity);
            prj.transform.parent = gameObject.transform;
        }
    }


    public override void Update()
    {
        base.Update();

        if (canAttack)
        {
            StartCoroutine(Rotate());
        }

    }
    public IEnumerator Rotate()
    {
        canAttack = false;
        float timer = 0;
        for (int i = 0; i < 91; i++)
        {
            timer += Time.deltaTime;
            transform.Rotate(0, 0, 1);
            yield return new WaitForSeconds(curve.Evaluate(timer));
        }

        yield return new WaitForSeconds(coolDown);
        canAttack = true;


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRotate : MonoBehaviour
{
   public Weapon weapon;

   
    void Start()
    {
        weapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0, j = 0; i < weapon.amount && j < 360; i++, j += 360 / weapon.amount)
        //{

        //    Vector3 pos = new Vector3(weapon.range * Mathf.Cos((j * Mathf.PI) / 180) + transform.position.x, weapon.range * Mathf.Sin((j * Mathf.PI) / 180) + transform.position.y, 0);

        //}

        //if (canRotate)
        //{
        //    StartCoroutine(Rotate(transform.position));
        //}
    }

    //public IEnumerator Rotate(Vector3 position)
    //{
    //    //Quaternion rot = gameObject.transform.rotation;
    //    canRotate = false;
    //    float angle = 180 + Mathf.Atan2(position.y, position.x) + Mathf.Rad2Deg;
    //    Debug.Log(angle);
    //    for (float i = angle; i < angle + 91; i++)
    //    {
            
    //        Vector3 pos = new Vector3(weapon.range * Mathf.Cos((i * Mathf.PI) / 180), weapon.range * Mathf.Sin((i * Mathf.PI) / 180), 0);
    //        gameObject.transform.position = pos;
    //       // gameObject.transform.Rotate(0,0,i);
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //    yield return new WaitForSeconds(4f);
    //    canRotate = true;
    //}
}

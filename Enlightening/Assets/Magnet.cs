using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : WeaponClass
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<OrbLogic>(out OrbLogic component))
        {

        }
    }
    public override void Start()
    {

    }

    // Update is called once per frame
    public override void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class Magnet : WeaponClass
{

    public float influenceRange;
    public float intensity;
    public Vector2 pullForce;


    // Update is called once per frame
    public override void Update()
    {

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Orb");
        if (gameObjects.Length > 0)
        {
            Debug.Log($"Orbs:{gameObjects.Length}");
            List<float> distances = new List<float>();
            for (int i = 0; i < gameObjects.Length; i++)
            {
                distances.Add(Vector2.Distance(gameObject.transform.position, gameObjects[i].transform.position));
            }

            for (int i = 0; i < gameObjects.Length; i++)
            {
                if (distances[i] <= influenceRange)
                {
                    Debug.Log($"{gameObjects[i]} close enough here: {distances[i]}");
                    pullForce = (transform.position - gameObjects[i].transform.position).normalized / distances[i] * intensity;
                    Debug.Log(pullForce);
                    gameObjects[i].GetComponent<Rigidbody2D>().AddForce(pullForce, ForceMode2D.Force);
                }

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWorldBounds : MonoBehaviour
{
    public static Bounds worldBounds;
    public GameObject Map;

    void Update()
    {
        var bounds = Map.GetComponent<BoxCollider2D>().bounds;
        worldBounds = bounds;
    }
}

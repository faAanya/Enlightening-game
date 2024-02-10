using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
   private LineRenderer line;
    [SerializeField] private Transform[] points;

    void Start()
    {
        line = GameObject.FindGameObjectWithTag("TeslaLaser").GetComponent<LineRenderer>();

        SetUtLine(points);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            line.SetPosition(i, points[i].position);
        }
    }
    public void SetUtLine(Transform[] points)
    {
        line.positionCount = points.Length;
        this.points = points;
    }

 
}

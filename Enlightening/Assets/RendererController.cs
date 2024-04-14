using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class RenderController : MonoBehaviour
{

    SpriteRenderer[] renderers;
    GameObject[] lights;
    private Camera cam;
    void Awake()
    {

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        renderers = FindObjectsOfType<SpriteRenderer>();

        lights = FindObjectsOfType<GameObject>();
        foreach (SpriteRenderer element in renderers)
        {
            if (element.gameObject.name != "Map")
            {
                Debug.Log(element.gameObject.name);
                Vector3 viewPos = cam.WorldToViewportPoint(element.transform.position);

                if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
                {
                    element.enabled = false;
                }
                else
                {
                    element.enabled = true;
                }


            }

        }
        foreach (GameObject e in lights)
        {
            if (e.gameObject.name != "Map")
            {
                if (e.gameObject.GetComponent<Light2D>() != null)
                {
                    Vector3 viewPos = cam.WorldToViewportPoint(e.transform.position);

                    if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
                    {
                        e.gameObject.GetComponent<Light2D>().enabled = false;
                    }
                    else
                    {
                        e.gameObject.GetComponent<Light2D>().enabled = true;
                    }
                }

            }
        }

    }

}

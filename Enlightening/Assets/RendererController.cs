using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class RenderController : MonoBehaviour
{

    SpriteRenderer[] renderers;
    GameObject[] obj;
    private Camera cam;
    void Awake()
    {

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {

        renderers = FindObjectsOfType<SpriteRenderer>();
        obj = FindObjectsOfType<GameObject>();

        foreach (GameObject element in obj)
        {
            if (element.gameObject.tag == "Map")
            {
                continue;
            }
            else
            {
                if (element.gameObject.GetComponent<Light2D>() != null)
                {
                    Vector3 viewPos = cam.WorldToViewportPoint(element.transform.position);

                    if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
                    {
                        element.gameObject.GetComponent<Light2D>().enabled = false;
                    }
                    else
                    {
                        element.gameObject.GetComponent<Light2D>().enabled = true;
                    }
                }
                else if (element.gameObject.GetComponent<Renderer>() != null)
                {
                    Vector3 viewPos = cam.WorldToViewportPoint(element.transform.position);

                    if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
                    {
                        element.gameObject.GetComponent<Renderer>().enabled = false;
                    }
                    else
                    {
                        element.gameObject.GetComponent<Renderer>().enabled = true;
                    }
                }
            }


        }

    }


}



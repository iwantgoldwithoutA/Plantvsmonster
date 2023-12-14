using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cam;

    GameObject lastRay;
    
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
  
            RayCast();
        
    }

    void RayCast()
    {
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition) , Vector2.zero);
        if (hit.collider != null)
        {
            //init set lastRay
            if (lastRay == null)
            {
                lastRay = hit.collider.gameObject;
            }

            if (hit.collider.gameObject != lastRay)
            {
                lastRay.GetComponent<BaseSystem>().NotHover();
                lastRay = hit.collider.gameObject;
            }

            lastRay.GetComponent<BaseSystem>().onRay();
        }
        else
        {
            if (lastRay)
            {
                lastRay.GetComponent<BaseSystem>().NotHover();
            }
        }
    }


}

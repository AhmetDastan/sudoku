using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Copyright (C) Xenfinity LLC - All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Bilal Itani <bilalitani1@gmail.com>, June 2017
 */

public class ObjectClicker : MonoBehaviour {



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))//Input.touchCount > 0
        {
            RaycastHit2D hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            hit = Physics2D.GetRayIntersection(ray);
            if (hit)//Raycast(ray, out hit, 100.0f))//ray, out hit, 
            {
                Debug.Log("icerde ve mouse pos " + Input.mousePosition);
                if (hit.transform != null)
                {


                    Debug.Log("ananasgsfsdasss " + hit.transform.name);
                }
            }
        }
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }


}

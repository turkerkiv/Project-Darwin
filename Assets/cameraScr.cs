using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScr : MonoBehaviour
{
    Camera cmr;
    void Start()
    {
        cmr = GetComponent<Camera>();
        InvokeRepeating("cam", 2f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void cam()
    {
        if (cmr.orthographicSize <= 5)
        {
            cmr.orthographicSize += 0.01f;
        }
    }
}

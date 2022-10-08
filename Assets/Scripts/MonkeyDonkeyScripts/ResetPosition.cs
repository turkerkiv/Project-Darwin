using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    Vector2 _positionAtStart;
    void Start()
    {
        _positionAtStart = transform.position;
    }

    void Update()
    {
        if (transform.position.x < -39.92f)
        {
            transform.position = _positionAtStart;
        }
    }
}

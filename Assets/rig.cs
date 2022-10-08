using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rig : MonoBehaviour
{
    [SerializeField] float speed = -2f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
   
    }
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

    }
}

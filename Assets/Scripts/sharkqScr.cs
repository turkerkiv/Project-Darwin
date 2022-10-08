using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharkqScr : MonoBehaviour
{
    CircleCollider2D circC;
    BoxCollider2D boxC;
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        anim.SetTrigger("playAnim");
    }
    void animEnd()
    {
        anim.speed = 0;
    }
}

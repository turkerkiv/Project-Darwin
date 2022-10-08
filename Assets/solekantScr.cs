using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solekantScr : MonoBehaviour
{
    CapsuleCollider2D cp;
    [SerializeField] float speed = 2f;
    Rigidbody2D rb;
    void Start()
    {
        cp = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
        if (collision.gameObject.tag == "Ground")
        {
            transform.localScale = new Vector3(1f, transform.localScale.y * -1f, 1f);
            transform.eulerAngles+= new Vector3(0f, 0f, 180f);
        }
    }

}

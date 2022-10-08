using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tiktaalikDirectionalMove : MonoBehaviour
{

    [SerializeField] float spd = 1f;
    Animator anim;
    [SerializeField] int skorHdf = 7;
    int skor = 0;

    void Start()
    {
        skor = 0;
        anim = GetComponent<Animator>();
        
    }
    private void FixedUpdate()
    {
        transform.eulerAngles -= new Vector3(0f, 0f, 0.0000001f);
        
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.left*Time.deltaTime*spd);
            anim.speed = 0.6f;    
        }
        else
        {
            anim.speed = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles += new Vector3(0f,0f,0.36f);
            
        }
            if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles -= new Vector3(0f,0f,0.36f);
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bitki")
        {
            if (skor <= skorHdf)
            {
                skor += 1;
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);

                SceneManager.LoadScene("yavrularakosus");
            }
        }

    }
 
}

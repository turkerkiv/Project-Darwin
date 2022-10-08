using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using MuiscFilesNN;
public class cerbugController : MonoBehaviour
{
    [SerializeField] float grav = 2f;
    [SerializeField] float jSpeed = 2f;
    float speed = 0.4f;
    Rigidbody2D rb;
    BoxCollider2D bxC;
    [SerializeField] bool isGround;
    private GameObject _music;
    private MuiscFiles muiscFiles;

    void Start()
    {
            _music = GameObject.Find("AudioManager");
        muiscFiles = _music.GetComponent(typeof(MuiscFiles)) as MuiscFiles;
        rb = GetComponent<Rigidbody2D>();
        bxC = GetComponent<BoxCollider2D>();
        rb.gravityScale = grav;
    }

    // Update is called once per frame
    void Update()
    {
        rb.gravityScale = grav;
        isGround = bxC.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && isGround)
        {
            rb.velocity = new Vector2(0f, jSpeed);
        }
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.tag == "Finish")
        {
            SceneManager.LoadScene("MonkeyDonkey");
        }
        if (collision.tag == "Bitki")
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag == "tetik")
        {
            speed = 0.1f;
        }
        if (collision.tag == "Elma")
        {
            AudioSource.PlayClipAtPoint(muiscFiles.music[0], gameObject.transform.position);
            Destroy(collision.gameObject);

        }
    }
}

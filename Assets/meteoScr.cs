using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MuiscFilesNN;

public class meteoScr : MonoBehaviour
{
    private GameObject _music;
    private MuiscFiles muiscFiles;
    BoxCollider2D bxC;
    CircleCollider2D cxC;
    Animator anim;
    bool OlerMi = false;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        _music = GameObject.Find("AudioManager");
        muiscFiles = _music.GetComponent(typeof(MuiscFiles)) as MuiscFiles;

        bxC = GetComponent<BoxCollider2D>();
        cxC = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (OlerMi)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                
                anim.SetTrigger("start");

            }
        }
        
    }
    void callInvoke()
    {
        Invoke("destroyObj", 0.7f);
    }
    void destroyObj()
    {
        Destroy(gameObject);
    }
    void OlerArtik()
    {
        AudioSource.PlayClipAtPoint(muiscFiles.music[1], gameObject.transform.position);
        OlerMi = true;
    }
    void dususSesi()
    {
        AudioSource.PlayClipAtPoint(muiscFiles.music[2], gameObject.transform.position);
    }
       
     
}

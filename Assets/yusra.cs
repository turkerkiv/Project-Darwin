using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yusra : MonoBehaviour
{
    
    void Start()
    {
        Invoke("asd", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void asd()
    {
        SceneManager.LoadScene("aslan1");
    }
}

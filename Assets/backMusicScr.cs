using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backMusicScr : MonoBehaviour {
    AudioSource audi;
    void Awake()
    {
        audi = GetComponent<AudioSource>();
    }
    void Start()
    {
        if(!audi.isPlaying)
        {
            audi.Play();
        }
    }
}

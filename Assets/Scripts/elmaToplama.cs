using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elmaToplama : MonoBehaviour
{
    AudioSource audioSource;
    int a;
    SpriteRenderer sprR;
    [SerializeField] List<Sprite> sprList;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sprR = GetComponent<SpriteRenderer>();
        a = Random.Range(0, 3);
        sprR.sprite = sprList[a];
    }


}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MuiscFilesNN;

public class bitkiToplama : MonoBehaviour
{
    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
            Destroy(gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
    private GameObject _music;
    private MuiscFiles muiscFiles;

    int a;
    SpriteRenderer sprR;
    [SerializeField] List<Sprite> sprList;
    private void Start()
    {
        _music = GameObject.Find("AudioManager");
        muiscFiles = _music.GetComponent(typeof(MuiscFiles)) as MuiscFiles;
        sprR = GetComponent<SpriteRenderer>();
        a = Random.Range(0, 3);
        sprR.sprite = sprList[a];
    }
    private void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(muiscFiles.music[0], _music.transform.position);
    }
}


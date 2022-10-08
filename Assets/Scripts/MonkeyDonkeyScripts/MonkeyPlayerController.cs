using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MonkeyPlayerController : MonoBehaviour
{
    [SerializeField] float _dashSpeed = 1f;
    [SerializeField] Slider _bananaSlider;
    [SerializeField] MonkeyDonkeySpawnManager _spawn;
    [SerializeField] TreeMovement _lastSceneMovement;
    TreeMovement _playerMovement;
    [SerializeField] TreeMovement _treeMovement;
    [SerializeField] GameObject _banana;
    [SerializeField] Canvas _start;
    [SerializeField] Canvas _aile;
    [SerializeField] GameObject _bakmucsi;
        AudioSource _audio;
    [SerializeField] AudioClip _clip;
    int _bananaCountToFinish = 6;
    BoxCollider2D _boxCollider;
    Rigidbody2D _playerRigidBody;
    Animator _animator;
    int _skor;
    bool _isOnTop;
    bool _isOnBottom;
    bool _isAtPosition;
    private void Awake()
    {
    }
    void StartTTT()
    {
        _start.gameObject.SetActive(false);
    }
    void Start()
    {
        _playerMovement = GetComponent<TreeMovement>();
        _bananaSlider.maxValue = _bananaCountToFinish;
        _lastSceneMovement.MoveSpeed = 0;
        _bananaSlider.value = 0;
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _playerRigidBody = GetComponent<Rigidbody2D>();
        Invoke("StartTTT", 8f);
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Move();
        if (_bananaSlider.value >= _bananaCountToFinish)
        {
            _bananaSlider.gameObject.SetActive(false);
            _spawn.CancelInvoke();
            _lastSceneMovement.MoveSpeed = -2.5f;
            _aile.gameObject.SetActive(false);
        }
        LoadScene();
    }

    void OnAnimationEnd()
    {
        _animator.enabled = false;
    }

    void Move()
    {
        if (_boxCollider.IsTouchingLayers(LayerMask.GetMask("Dallar")) && _isAtPosition)
        {
            if (Input.GetKeyDown(KeyCode.W) && !_isOnTop)
            {
                _animator.enabled = true;
                _animator.SetTrigger("wbasma");
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                _animator.enabled = true;
                _animator.SetTrigger("dbasma");
            }
            if (Input.GetKeyDown(KeyCode.S) && !_isOnBottom)
            {
                _animator.enabled = true;
                _animator.SetTrigger("sbasma");
            }
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Dal1"))
        {
            Debug.Log("yukardayız");
            _animator.SetBool("asagidami", false);
            _animator.SetBool("ortadami", false);
            _animator.SetBool("yukaridami", true);
            _isOnTop = true;
            _isOnBottom = false;
        }
        if (other.gameObject.CompareTag("Dal2"))
        {
            Debug.Log("ortadayız");
            _animator.SetBool("asagidami", false);
            _animator.SetBool("yukaridami", false);
            _animator.SetBool("ortadami", true);
            _isOnBottom = false;
            _isOnTop = false;
        }
        if (other.gameObject.CompareTag("Dal3"))
        {
            Debug.Log("asagıdayız");
            _animator.SetBool("ortadami", false);
            _animator.SetBool("yukaridami", false);
            _animator.SetBool("asagidami", true);
            _isOnBottom = true;
            _isOnTop = false;
        }
        if (other.gameObject.CompareTag("herihtimale"))
        {
            SceneManager.LoadScene("MonkeyDonkey");
        }

        if (gameObject.transform.position.x > other.gameObject.transform.position.x)
            transform.Translate(new Vector2(-0.5f, 0) * Time.deltaTime);
        if (gameObject.transform.position.x < other.gameObject.transform.position.x)
            transform.Translate(new Vector2(0.5f, 0) * Time.deltaTime);

        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("yerdeyiz");
            _bakmucsi.SetActive(false);
            _lastSceneMovement.MoveSpeed = 2.5f;
            _playerMovement.MoveSpeed = 0.8f;
            _audio.PlayOneShot(_clip, 0.15f);
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("banana"))
        {
            Destroy(other.gameObject);
            _skor += 1;
            _bananaSlider.value = _skor;
            _audio.Play();
        }
        if (other.CompareTag("MovementBound"))
        {
            _isAtPosition = true;
        }
        if (other.gameObject.CompareTag("Stop"))
        {
            Instantiate(_banana, new Vector2(transform.position.x + 1f, transform.position.y), _banana.transform.rotation, transform);
            Instantiate(_banana, new Vector2(transform.position.x + 1.3f, transform.position.y), _banana.transform.rotation, transform);
            Instantiate(_banana, new Vector2(transform.position.x + 1.5f, transform.position.y), _banana.transform.rotation, transform);
            Instantiate(_banana, new Vector2(transform.position.x + 1.7f, transform.position.y), _banana.transform.rotation, transform);
            Instantiate(_banana, new Vector2(transform.position.x + 1.9f, transform.position.y), _banana.transform.rotation, transform);
            Instantiate(_banana, new Vector2(transform.position.x + 2.1f, transform.position.y), _banana.transform.rotation, transform);
            _playerMovement.MoveSpeed = 0.10f;
            Invoke("Ending", 5f);
        }
        if (other.tag == "Finish")
        {
            SceneManager.LoadScene("AslanBossFight");
        }
    }
    void LoadScene()
    {
        if (transform.position.x < -12f)
            SceneManager.LoadScene("MonkeyDonkey");
    }
    void Ending()
    {
        SceneManager.LoadScene("AslanBossFight");
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MovementBound"))
        {
            _isAtPosition = false;
        }
    }
}

/*
if (Input.GetKeyDown(KeyCode.W))
     {
         _playerRigidBody.constraints = RigidbodyConstraints2D.None;
         _playerRigidBody.AddForce(new Vector2(_dashSpeed, _dashSpeed * 1.5f), ForceMode2D.Impulse);
     }
     if (Input.GetKeyDown(KeyCode.D))
     {
         _playerRigidBody.constraints = RigidbodyConstraints2D.None;
         _playerRigidBody.AddForce(new Vector2(_dashSpeed, _dashSpeed), ForceMode2D.Impulse);
     }
     if (Input.GetKeyDown(KeyCode.S))
     {
         _playerRigidBody.constraints = RigidbodyConstraints2D.None;
         _playerRigidBody.AddForce(new Vector2(_dashSpeed, _dashSpeed / 1.3f), ForceMode2D.Impulse);
     }*/

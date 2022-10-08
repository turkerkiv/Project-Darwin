using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ApePlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _jumpSpeed = 1f;
    [SerializeField] Image[] _playersHealth;
    Rigidbody2D _playerRigidbody;
    CapsuleCollider2D _playerCollider;
    Animator _anim;
    int _playerHealth = 3;
    float _horizontalInput;
    float _verticalInput;
    public bool IsLookingRight { get; set; }
    bool _isOnGround;
    float _timer = 2.5f;
    bool _isHit;
    AudioSource demne ;

    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerCollider = GetComponent<CapsuleCollider2D>();
        _anim = GetComponent<Animator>();
        IsLookingRight = true;
        demne = GetComponent<AudioSource>();
    }

    void Update()
    {
        MovePlayer();
        Jump();
        ScalePlayer();
        Die();

        if (_isHit)
        {
            _timer += Time.deltaTime;
        }


        _isOnGround = _playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        _anim.SetFloat("Speed", Mathf.Abs(_playerRigidbody.velocity.x));
        _anim.SetBool("isGround", _isOnGround);

    }

    void Die()
    {
        if (_playerHealth <= 0)
        {
            transform.position = new Vector2(transform.position.x, -3.70f);
            transform.eulerAngles = new Vector3(0, 0, 92.29f);
            _playerCollider.enabled = false;
            _playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            Invoke("ReloadScene", 1.5f);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene("AslanBossFight");
    }

    void MovePlayer()
    {
        _horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(_playerRigidbody.velocity.x) < 10)
        {
            _playerRigidbody.velocity += Vector2.right * _horizontalInput * _moveSpeed;
        }
    }

    void ScalePlayer()
    {
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(Mathf.Sign(_horizontalInput), 1);
            if (_horizontalInput < 0)
                IsLookingRight = false;
            else
                IsLookingRight = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
        }
        if (other.gameObject.CompareTag("Enemy") && _timer > 2f)
        {
            _timer = 0;
            _isHit = true;
            _playersHealth[_playerHealth - 1].gameObject.SetActive(false);
            _playerHealth -= 1;
            demne.Play();
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("LionsTop"))
        {
            if (transform.localScale.x == 1)
                _playerRigidbody.AddForce(new Vector2(1000f, 1000f), ForceMode2D.Impulse);
            if (transform.localScale.x == -1)
                _playerRigidbody.AddForce(new Vector2(-1000f, 1000f), ForceMode2D.Impulse);
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _playerRigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    ApePlayerController _apePlayerController;
    Rigidbody2D _spearRigidbody;
    GameObject _enemy;
    bool _isThrew;

    private void Awake()
    {
        _apePlayerController = FindObjectOfType<ApePlayerController>();
    }
    void Start()
    {
        _spearRigidbody = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        MoveSpear();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Freeze();
            Destroy(GetComponentInChildren<CapsuleCollider2D>());
            Destroy(GetComponentInChildren<BoxCollider2D>()); 
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    void MoveSpear()
    {
        if (!_isThrew && _apePlayerController.IsLookingRight)
        {
            _spearRigidbody.AddForce(new Vector2(1f, 0.5f) * _moveSpeed, ForceMode2D.Impulse);
            _isThrew = true;
        }
        if (!_isThrew && !_apePlayerController.IsLookingRight)
        {
            _spearRigidbody.AddForce(new Vector2(-1f, 0.5f) * _moveSpeed, ForceMode2D.Impulse);
            _isThrew = true;
        }
    }
    void Freeze()
    {
        _spearRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}

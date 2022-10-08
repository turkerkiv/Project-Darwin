using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _attackSpeed = 1f;
    [SerializeField] float _attackDelay = 1f;
    [SerializeField] float _enemyHealth = 1f;
    [SerializeField] float _spearDamage = 1f;
    [SerializeField] Slider _slider;

    Animator _animator;
    Rigidbody2D _enemyRigidbody;
    bool _isOnGround;
    float _timer;

    void Start()
    {
        _enemyRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _timer = _attackDelay;
        _slider.maxValue = _enemyHealth;
        _slider.value = _enemyHealth;
    }

    void Update()
    {
        MoveEnemy();
        Die();
    }
    void Die()
    {
        if (_slider.value <= 0)
        {
            transform.position = new Vector2(transform.position.x, -3.69f);
            transform.localScale = new Vector3(1, -1, 1);
            _enemyRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            _slider.gameObject.SetActive(false);

            Invoke("loadScene", 4f);
        }
    }
    void loadScene()
    {
        Debug.Log("sdkfgmklsdfg");
        SceneManager.LoadScene("bitterend");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
        }
        if (other.gameObject.CompareTag("Spear"))
        {
            _slider.value -= _spearDamage;
        }
    }

    void MoveEnemy()
    {
        Vector2 gap = new Vector2(_player.transform.position.x - transform.position.x, transform.position.y);
        _timer += Time.deltaTime;

        if ((transform.position.x < _player.transform.position.x - 6 || transform.position.x > _player.transform.position.x + 6))
        {
            if (_isOnGround)
            {
                _enemyRigidbody.velocity = gap.normalized * _moveSpeed;
                _animator.SetFloat("speed", 2f);
            }
        }
        else
        {
            if (_timer > _attackDelay)
            {
                _enemyRigidbody.velocity = new Vector2(0, 0);
                _animator.SetFloat("speed", Mathf.Abs(_enemyRigidbody.velocity.x));
                _animator.SetTrigger("attack");
                _enemyRigidbody.AddForce(gap.normalized * _attackSpeed, ForceMode2D.Impulse);
                _timer = 0;
            }
        }

        ScaleEnemy(gap);
    }

    void ScaleEnemy(Vector2 gap)
    {
        transform.localScale = new Vector2(-Mathf.Sign(gap.x), 1);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    float _verticalInput;
    float _horizontalInput;

    void Start()
    {
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(_horizontalInput * Time.deltaTime * _moveSpeed, _verticalInput * Time.deltaTime * _moveSpeed));
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(Mathf.Sign(_horizontalInput) * -1, 1);
        }

        /* _verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.right * _verticalInput * Time.deltaTime * _moveSpeed); //object ileri geri

        if (transform.localScale.x == -1)
        {
            if (transform.eulerAngles.z > 310 || transform.eulerAngles.z < 50)
            {
                _horizontalInput = Input.GetAxis("Horizontal");
                transform.Rotate(Vector3.forward, -_horizontalInput * Time.deltaTime * _rotationSpeed);
            }
            else
            {
                transform.Rotate(Vector3.forward, Mathf.Sign(transform.rotation.z) * -1f);
            }

            transform.localScale = new Vector2(Mathf.Sign(_verticalInput) * -1, 1);
        }
        else if (transform.localScale.x == 1)
        {
            if (transform.eulerAngles.z > 310 || transform.eulerAngles.z < 50)
            {
                _horizontalInput = Input.GetAxis("Horizontal");
                transform.Rotate(Vector3.forward, _horizontalInput * Time.deltaTime * _rotationSpeed);
            }
            else
            {
                transform.Rotate(Vector3.forward, Mathf.Sign(transform.rotation.z) * -1f);
            }

            transform.localScale = new Vector2(Mathf.Sign(_verticalInput) * -1, 1); 
        } */
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } 
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("tiktaalikBitkiToplama");
        }
    }
}

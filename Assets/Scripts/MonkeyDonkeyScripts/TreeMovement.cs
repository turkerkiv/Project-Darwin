using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime);
    }
}

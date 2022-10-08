using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    [SerializeField] float _destroyingDelay = 1f;
    float _destroyingTimer;

    void Start()
    {

    }

    void Update()
    {
        DestroySpear();
    }
    
    void DestroySpear()
    {
        _destroyingTimer += Time.deltaTime;

        if (_destroyingTimer > _destroyingDelay)
        {
            Destroy(gameObject);
            _destroyingTimer = 0;
        }
    }
}

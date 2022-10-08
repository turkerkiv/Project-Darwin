using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _spear;
    [SerializeField] GameObject _player;
    [SerializeField] float _throwDelay = 1f;
    ApePlayerController _apePlayerController;
    [SerializeField] Animator _anim;
    float _spawningTimer;

    void Start()
    {
        _apePlayerController = _player.GetComponent<ApePlayerController>();
        _spawningTimer = _throwDelay;
    }

    void Update()
    {
        SpawnSpear();
    }

    void SpawnSpear()
    {
        _spawningTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && _spawningTimer > _throwDelay && _apePlayerController.IsLookingRight)
        {
            Instantiate(_spear, _player.transform.position, _spear.transform.rotation);
            _spawningTimer = 0;
            _anim.SetTrigger("Mizrak");
            
        }
        if (Input.GetKeyDown(KeyCode.F) && _spawningTimer > _throwDelay && !_apePlayerController.IsLookingRight)
        {

            GameObject sc = Instantiate(_spear, _player.transform.position, _spear.transform.rotation);
            sc.transform.eulerAngles = new Vector3(0, -180, -20.957f);
            _spawningTimer = 0;
            _anim.SetTrigger("Mizrak");
        }
    }

}

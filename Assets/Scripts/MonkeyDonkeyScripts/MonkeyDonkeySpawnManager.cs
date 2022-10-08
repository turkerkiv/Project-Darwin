using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyDonkeySpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _agac;
    [SerializeField] GameObject _muz;
    [SerializeField] GameObject[] _dallar;
    [SerializeField] float _spawnRate = 1f;
    [SerializeField] float _startDelay = 1f;

    void Start()
    {
        InvokeRepeating("SpawnTree", _startDelay, _spawnRate);
        // InvokeRepeating("SpawnBanana", _startDelay, _spawnRate);
    }

    void Update()
    {

    }

    void SpawnTree()
    {
        GameObject cloneTree = Instantiate(_agac, new Vector2(12f, -1.11f), _agac.transform.rotation);
        float[] randomY = new float[] { -1f, 0.85f, 2.7f };
        int randomI = Random.Range(0, 3);
        Instantiate(_muz, new Vector2(13f, randomY[randomI]), _muz.transform.rotation, cloneTree.transform); //bananaspawn

    }
    /* void SpawnBanana()
     {
         int randomY = Random.Range(0, 3);
         Instantiate(_muz, new Vector2(0.46f, randomY), _muz.transform.rotation);
         _muz
     }
     */
}

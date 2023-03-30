using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateChar : MonoBehaviour
{
    [SerializeField]
    private GameObject _charWar, _charVal, _charWiz;

    void Start()
    {
        Instantiate(_charWar, transform.position, Quaternion.identity);
        Instantiate(_charVal, transform.position, Quaternion.identity);
        Instantiate(_charWiz, transform.position, Quaternion.identity);
    }
}

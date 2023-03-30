using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private GameObject adventurerObject;
    public bool leaving = false;

    private void Update()
    {
        if (leaving)
            DestroyGameObject();
    }
    public void DestroyGameObject()
    {
        Destroy(adventurerObject);
    }
}

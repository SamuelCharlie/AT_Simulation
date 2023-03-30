using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class EnemyRoom : MonoBehaviour
{
    public GameObject enemyRoomPrefab = null;

    private RaycastHit _hit;


    private void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray, Mathf.Infinity);

        if (Physics.Raycast(ray, out _hit, Mathf.Infinity))
        {
            transform.position = _hit.point;
        }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray, Mathf.Infinity);

        if (Physics.Raycast(ray, out _hit, Mathf.Infinity))
        {
            transform.position = _hit.point;
        }

        if (Input.GetMouseButton(0))
        {
            Destroy(gameObject);
        }
    }
}

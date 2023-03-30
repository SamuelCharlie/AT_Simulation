using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class HealingRoom : MonoBehaviour
{
    [SerializeField] private MovementSM movementSM;
    //[SerializeField] private PlacementPositions _viablePlace;
    public GameObject healingRoomPrefab = null;
    //GameObject closestPosition = null;

    private RaycastHit _hit;
    private bool _room;
    //private float closest = Mathf.Infinity;

    private void Awake()
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

    /*public GameObject FindClosestAvailablePlacementPoint()
    {
        for (int i = 0; i < _viablePlace.placePos.Count; i++)
        {
            Debug.Log(_viablePlace.placePos[i].transform.position);
            float dist = Vector3.Distance(_viablePlace.placePos[i].transform.position, Mouse.current.position.ReadValue());
            Debug.Log(dist);
            if (dist < closest)
            {
                closest = dist;
                closestPosition = _viablePlace.placePos[i];
            }
        }
        return closestPosition;
    }*/
}

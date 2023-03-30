using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRoom : MonoBehaviour
{
    public RoomData placementRoomData;
    private RoomData _privPlacementRoomData;

    [SerializeField] private bool built = false;

    public GameObject buildHealingRoomPrefab = null;
    public GameObject buildEnemyRoomPrefab = null;
    public GameObject buildLootRoomPrefab = null;

    private void Start()
    {
        _privPlacementRoomData = GameObject.Find("Manager").GetComponent<RoomData>();
    }

    private void OnMouseDown()
    {
        if (_privPlacementRoomData.roomType == 1)
        {
            Debug.Log("hit");
            Instantiate(buildHealingRoomPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if(_privPlacementRoomData.roomType == 2)
        {
            Debug.Log("hit");
            Instantiate(buildEnemyRoomPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (_privPlacementRoomData.roomType == 3)
        {
            Debug.Log("hit");
            Instantiate(buildLootRoomPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        _privPlacementRoomData.roomType = 0;
    }
}

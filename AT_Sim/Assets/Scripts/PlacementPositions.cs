using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementPositions : MonoBehaviour
{
    private RoomData _privRoomData;

    public List<GameObject> placePos;

    void Start()
    {
        _privRoomData = GameObject.Find("Manager").GetComponent<RoomData>();
        GatherList();
    }

    public void GatherList()
    {
        placePos = _privRoomData.placementPositions;
    }
}

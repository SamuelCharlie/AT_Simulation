using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : MonoBehaviour
{
    public List<bool> occupiedHealingRoom = new List<bool>();
    public List<GameObject> placementPositions = new List<GameObject>();
    public bool occupied = false;

    public int roomType = 0;
    public int healingRoomsAmount = 0;

    private void Start()
    {

    }

    public void AddHealingRoom()
    {
        occupiedHealingRoom.Add(occupied);
    }
}

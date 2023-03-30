using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomButtonPress : MonoBehaviour
{
    public RoomData buttonRoomData;
    private RoomData _privButtonRoomData;

    [SerializeField] private GameObject _healingBlueprintPrefab;
    [SerializeField] private GameObject _enemyBlueprintPrefab;
    [SerializeField] private GameObject _lootBlueprintPrefab;

    private void Start()
    {
        _privButtonRoomData = GameObject.Find("Manager").GetComponent<RoomData>();
    }

    public void SpawnHealingRoom()
    {
        _privButtonRoomData.roomType = 1;
        Instantiate(_healingBlueprintPrefab);
    }

    public void SpawnEnemyRoom()
    {
        _privButtonRoomData.roomType = 2;
        Instantiate(_enemyBlueprintPrefab);
    }

    public void SpawnLootRoom()
    {
        _privButtonRoomData.roomType = 3;
        Instantiate(_lootBlueprintPrefab);
    }
}

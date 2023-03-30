using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector] public WanderState wanderState;
    [HideInInspector] public FightState fightState;
    [HideInInspector] public LootState lootState;
    [HideInInspector] public RestState restState;
    [HideInInspector] public LeaveState leaveState;

    public PlayerData playerData;
    public RoomData roomData;

    public Transform advTransform = null;
    public List<Transform> healingCircles = new List<Transform>();
    public int _amountOfHealingRooms = 0;

    public float satisfaction = 0;
    public float activity = 0;
    public float energy = 0;

    public void Awake()
    {
        wanderState = new WanderState(this);
        fightState = new FightState(this);
        lootState = new LootState(this);
        restState = new RestState(this);
        leaveState = new LeaveState(this);
    }

    protected override BaseState GetInitialState()
    {
        return wanderState;
    }

    /*protected override BaseState GetCollisionState()
    {
        Debug.Log("Collision");
        return wanderState;
    }*/
}

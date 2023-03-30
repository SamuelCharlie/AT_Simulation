using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootState : BaseState
{
    public LootState(MovementSM stateMachine) : base("LootState", stateMachine) { }
    public MovementSM movementSM;
    public WanderState wanderState;

    private float _charSpeed = 0;

    [SerializeField] private Vector2 _lootPosition;
    [SerializeField] private GameObject _loot;
    public override void Enter()
    {
        base.Enter();
        _charSpeed = 5f;

        _loot = GameObject.FindGameObjectWithTag("Loot");
        if (_loot != null)
        {
            _lootPosition = new Vector2(_loot.transform.position.x, _loot.transform.position.y);
        }
        else if (_loot == null)
        {
            _stateMachine.ChangeState(((MovementSM)_stateMachine).wanderState);
        }
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        LootRoom();
    }

    private void LootRoom()
    {        
        ((MovementSM)_stateMachine).advTransform.transform.position =
            Vector2.MoveTowards(((MovementSM)_stateMachine).advTransform.transform.position, _lootPosition, _charSpeed * Time.deltaTime);

        if ((((MovementSM)_stateMachine).advTransform.transform.position.x == _lootPosition.x) &&
            (((MovementSM)_stateMachine).advTransform.transform.position.y == _lootPosition.y))
        {
            ((MovementSM)_stateMachine).satisfaction += 2 * Time.deltaTime;
        }

            if (((MovementSM)_stateMachine).satisfaction >= 90)
            _stateMachine.ChangeState(((MovementSM)_stateMachine).wanderState);
    }
}

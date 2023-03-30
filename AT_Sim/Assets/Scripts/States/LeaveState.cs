using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveState : BaseState
{
    public LeaveState(MovementSM stateMachine) : base("LeaveState", stateMachine) { }
    public MovementSM movementSM;
    public WanderState wanderState;

    public PlayerData playerDataLeave;

    private float _charSpeed = 0;

    [SerializeField] private Vector2 _exitPosition;
    [SerializeField] private GameObject _exitPortal;

    public override void Enter()
    {
        base.Enter();
        playerDataLeave = ((MovementSM)_stateMachine).playerData;

        _charSpeed = 5f;

        _exitPortal = GameObject.FindGameObjectWithTag("ExitPortal");
        _exitPosition = new Vector2(_exitPortal.transform.position.x, _exitPortal.transform.position.y);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        Exit();
    }

    private void Exit()
    {
        ((MovementSM)_stateMachine).satisfaction -= 1 * Time.deltaTime;

        ((MovementSM)_stateMachine).advTransform.transform.position =
            Vector2.MoveTowards(((MovementSM)_stateMachine).advTransform.transform.position, _exitPosition, _charSpeed * Time.deltaTime);
        
        if (((MovementSM)_stateMachine).advTransform.transform.position == _exitPortal.transform.position)
        {
            playerDataLeave.leaving = true;
        }
    }
}

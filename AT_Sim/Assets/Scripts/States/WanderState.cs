using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : BaseState
{
    public WanderState(MovementSM stateMachine) : base("WanderState", stateMachine) { }
    public MovementSM movementSM;

    public float _charSpeed = 0f;
    public float _range = 0f;
    public float _maxDistance = 0f;

    private bool _inCentreOfScene = false;

    private Vector2 _waypoint;

    public override void Enter()
    {
        base.Enter();

        _charSpeed = 5f;
        _range = 0.5f;
        _maxDistance = 7f;

        SetDestination();
    }

    public override void UpdateCollisisons()
    {
        base.UpdateCollisisons();
        MoveChar();
    }

    private void MoveChar()
    {
        ((MovementSM)_stateMachine).satisfaction -= 2 * Time.deltaTime;

        ((MovementSM)_stateMachine).advTransform.transform.position = 
            Vector2.MoveTowards(((MovementSM)_stateMachine).advTransform.transform.position, _waypoint, _charSpeed * Time.deltaTime);
        if (Vector2.Distance(((MovementSM)_stateMachine).advTransform.transform.position, _waypoint) < _range)
        {
            SetDestination();
        }
    }

    private void SetDestination()
    {
        StateTransition();

        if (!_inCentreOfScene)
        {
            _waypoint = new Vector2(Random.Range(-_maxDistance, _maxDistance), 
                Random.Range(-_maxDistance, _maxDistance));
            //_inCentreOfScene = true;
        }  
        /*else if (_inCentreOfScene)
            _waypoint = new Vector2(movementSM.transform.position.x + Random.Range(-movementSM._maxDistance, movementSM._maxDistance), 
                movementSM.transform.position.y + Random.Range(-movementSM._maxDistance, movementSM._maxDistance));*/
    }

    private void StateTransition()
    {
        if (((MovementSM)_stateMachine).satisfaction <= 75)
            ((MovementSM)_stateMachine).activity = Random.Range(0, 3);
        if (((MovementSM)_stateMachine).satisfaction <= 70)
            _stateMachine.ChangeState(((MovementSM)_stateMachine).leaveState);
        //Debug.Log(((MovementSM)_stateMachine).activity);
        if (((MovementSM)_stateMachine).activity == 1)
        {
            ((MovementSM)_stateMachine).activity = 0;
            _stateMachine.ChangeState(((MovementSM)_stateMachine).fightState);
        }
        else if (((MovementSM)_stateMachine).activity == 2)
        {
            ((MovementSM)_stateMachine).activity = 0;
            _stateMachine.ChangeState(((MovementSM)_stateMachine).lootState);
        }
    }
}

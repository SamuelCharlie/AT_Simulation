using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightState : BaseState
{
    public FightState(MovementSM stateMachine) : base("FightState", stateMachine) { }
    public MovementSM movementSM;
    public WanderState wanderState;

    private float _charSpeed = 0;

    [SerializeField] private Vector2 _enemyPosition;
    [SerializeField] private GameObject _enemy = null;

    public override void Enter()
    {
        base.Enter();

        _charSpeed = 5f;

        _enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (_enemy != null)
        {
            _enemyPosition = new Vector2(_enemy.transform.position.x, _enemy.transform.position.y);
        }
        else if(_enemy == null)
        {
            _stateMachine.ChangeState(((MovementSM)_stateMachine).wanderState);
        }
        
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        EngageEnemy();
    }

    private void EngageEnemy()
    {
        ((MovementSM)_stateMachine).advTransform.transform.position =
            Vector2.MoveTowards(((MovementSM)_stateMachine).advTransform.transform.position, _enemyPosition, _charSpeed * Time.deltaTime);

        if ((((MovementSM)_stateMachine).advTransform.transform.position.x == _enemyPosition.x) &&
            (((MovementSM)_stateMachine).advTransform.transform.position.y == _enemyPosition.y))
        {
            ((MovementSM)_stateMachine).satisfaction += 2 * Time.deltaTime;
            ((MovementSM)_stateMachine).energy -= 1 * Time.deltaTime;
        }

            if (((MovementSM)_stateMachine).satisfaction >= 90)
            _stateMachine.ChangeState(((MovementSM)_stateMachine).wanderState);

        if (((MovementSM)_stateMachine).energy <= 90)
            _stateMachine.ChangeState(((MovementSM)_stateMachine).restState);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestState : BaseState
{
    public RestState(MovementSM stateMachine) : base("RestState", stateMachine) { }
    public MovementSM movementSM;
    public WanderState wanderState;

    private float _charSpeed = 0;

    [SerializeField] private Vector2 _restPosition;
    [SerializeField] private GameObject _restCircle;
    private List<bool> _occupyingHealingRoom = new List<bool>();
    private int _firstTime = 0;
    private bool _occupyingRoom = false;

    public override void Enter()
    {
        base.Enter();

        _charSpeed = 5f;
        ((MovementSM)_stateMachine)._amountOfHealingRooms = ((MovementSM)_stateMachine).roomData.healingRoomsAmount;
        Debug.Log(((MovementSM)_stateMachine)._amountOfHealingRooms);
        if (((MovementSM)_stateMachine)._amountOfHealingRooms == 0)
        {
            Debug.Log("If");
            _restCircle = GameObject.FindGameObjectWithTag("HealCircle");
            ((MovementSM)_stateMachine)._amountOfHealingRooms++;
            _restCircle.GetComponentInParent<RoomData>().occupiedHealingRoom[((MovementSM)_stateMachine)._amountOfHealingRooms - 1] = true;

            ((MovementSM)_stateMachine).healingCircles.Add(_restCircle.transform);
            _restPosition = new Vector2(((MovementSM)_stateMachine).healingCircles[((MovementSM)_stateMachine)._amountOfHealingRooms - 1].transform.position.x,
                ((MovementSM)_stateMachine).healingCircles[((MovementSM)_stateMachine)._amountOfHealingRooms - 1].transform.position.y);

            _restCircle = null;
            ((MovementSM)_stateMachine).roomData.healingRoomsAmount = ((MovementSM)_stateMachine)._amountOfHealingRooms;
        }
        /*else if (((MovementSM)_stateMachine)._amountOfHealingRooms >= 1)
        {
            Debug.Log("Else");
            for (int i = 0; i < ((MovementSM)_stateMachine)._amountOfHealingRooms; i++)
            {
                _restCircle = GameObject.FindGameObjectWithTag("HealCircle");
                if (((MovementSM)_stateMachine).healingCircles.Contains(_restCircle.transform))
                {
                    if (!_occupyingHealingRoom[i - 1])
                    {
                        _occupyingHealingRoom[i - 1] = _restCircle.GetComponentInParent<RoomData>().occupiedHealingRoom[i - 1] = true;
                        _restPosition = new Vector2(((MovementSM)_stateMachine).healingCircles[i - 1].transform.position.x,
                        ((MovementSM)_stateMachine).healingCircles[i - 1].transform.position.y);
                        _restCircle = null;
                    }
                }
                else
                {
                    ((MovementSM)_stateMachine)._amountOfHealingRooms++;
                    _restCircle.GetComponentInParent<RoomData>().occupiedHealingRoom[((MovementSM)_stateMachine)._amountOfHealingRooms - 1] = true;

                    ((MovementSM)_stateMachine).healingCircles.Add(_restCircle.transform);
                    _restPosition = new Vector2(((MovementSM)_stateMachine).healingCircles[((MovementSM)_stateMachine)._amountOfHealingRooms - 1].transform.position.x,
                        ((MovementSM)_stateMachine).healingCircles[((MovementSM)_stateMachine)._amountOfHealingRooms - 1].transform.position.y);
                    _restCircle = null;
                }
            }
        }*/
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        Rest();
    }

    private void Rest()
    {
        ((MovementSM)_stateMachine).advTransform.transform.position =
            Vector2.MoveTowards(((MovementSM)_stateMachine).advTransform.transform.position, _restPosition, _charSpeed * Time.deltaTime);

        if ((((MovementSM)_stateMachine).advTransform.transform.position.x == _restPosition.x) && 
            (((MovementSM)_stateMachine).advTransform.transform.position.y == _restPosition.y))
        {
            //((MovementSM)_stateMachine).satisfaction -= (1/2) * Time.deltaTime;
            ((MovementSM)_stateMachine).energy += 2 * Time.deltaTime;
        }
        
        if (((MovementSM)_stateMachine).energy >= 100)
            _stateMachine.ChangeState(((MovementSM)_stateMachine).wanderState);

    }
}

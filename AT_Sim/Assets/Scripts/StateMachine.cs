using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    BaseState currentState;
    [SerializeField] private int _debugState = 0;

    private void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }

    private void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }

    private void FixedUpdate()
    {
        if (currentState != null)
            currentState.UpdateCollisisons();
    }

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState = GetCollisionState();
    }*/

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    protected virtual BaseState GetCollisionState()
    {
        return null;
    }

    private void OnGUI()
    {
        if (_debugState >= 1)
        {
            string content = currentState != null ? currentState.name : "(no current state)";
            GUILayout.Label($"<color='white'><size=40>{content}</size></color>");
        }
    }
}

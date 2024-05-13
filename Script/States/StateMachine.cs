using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    public BaseState activeState;
    // Start is called before the first frame update

    public void Initialise()
    {
        // patrolstate = new PatrolState();
        ChangeState(new PatrolState());

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }
    }
    public void ChangeState(BaseState newState)
    {
        activeState?.Exit();
        activeState = newState;
        if (activeState != null)
        {
            activeState.stateMachine = this;
            //assign the state machine to the new state
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState
{
    private float searchTimer;
    private float moveTimer;
    // Start is called before the first frame update
    public override void Enter()
    {
        // throw new System.NotImplementedException();
        enemy.Agent.SetDestination(enemy.LastKnownPosition);
    }
    public override void Perform()
    {
        // throw new System.NotImplementedException();
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
        if (enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance)
        {
            searchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;
            if (moveTimer > Random.Range(3, 5))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            if (searchTimer > 10)
            {
                stateMachine.ChangeState(new SearchState());
            }
        }
    }
    public override void Exit()
    {
        // throw new System.NotImplementedException();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex;
    public float waitTimer;
    // Start is called before the first frame update
    public override void Enter()
    {
        // throw new System.NotImplementedException();
    }

    public override void Perform()
    {
        PatrolCycle();
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }

    public override void Exit()
    {
        // throw new System.NotImplementedException();
    }
    //DECOMMENTE SI TU REUTILISES LOL
    // public void PatrolCycle()
    // {
    //     // Calculate the distance between the agent and its destination
    //     float distanceToDestination = Vector3.Distance(enemy.Agent.transform.position, enemy.path.waypoints[waypointIndex].position);

    //     // Cycle through the waypoints
    //     if (distanceToDestination < 0.5f)
    //     {
    //         waitTimer += Time.deltaTime;
    //         if (waitTimer > 3)
    //         {
    //             if (waypointIndex < enemy.path.waypoints.Count - 1)
    //                 waypointIndex++;
    //             else
    //                 waypointIndex = 0;

    //             enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
    //             waitTimer = 0;
    //         }
    //     }
    // }
    public void PatrolCycle()
    {
        // Find the player object
        GameObject player = GameObject.FindWithTag("Player");

        // Check if the player object was found
        if (player != null)
        {
            // Check if the NavMeshAgent is enabled and on the NavMesh
            if (enemy.Agent.isOnNavMesh)
            {
                // Set the player's position as the enemy's destination
                enemy.Agent.SetDestination(player.transform.position);

                // Calculate the distance between the enemy and the player
                float distanceToPlayer = Vector3.Distance(enemy.Agent.transform.position, player.transform.position);

                // If the enemy is close to the player
                if (distanceToPlayer < 0.5f)
                {
                    // Implement behavior when the enemy reaches the player
                }
            }
        }
    }
}

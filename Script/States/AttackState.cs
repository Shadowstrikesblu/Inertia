using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;


    public override void Enter()
    {
        // throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        // throw new System.NotImplementedException();
    }

    public override void Perform()
    {
        // throw new System.NotImplementedException();
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if (shotTimer > enemy.fireRate)
            {
                Shoot();

            }
            if (moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            enemy.LastKnownPosition = enemy.Player.transform.position;
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 8)
            {
                //dss
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    // Start is called before the first frame update
    public void Shoot()
    {
        Transform gunbarrel = enemy.gunBarrel;
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet"), gunbarrel.position, gunbarrel.rotation) as GameObject;
        Vector3 direction = (enemy.Player.transform.position - gunbarrel.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * direction * 40;
        // Debug.Log("Pew Pew");
        shotTimer = 0;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

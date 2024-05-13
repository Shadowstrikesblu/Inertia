using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    private Vector3 lastKnownPosition;
    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }
    public Vector3 LastKnownPosition { get => lastKnownPosition; set => lastKnownPosition = value; }
    public Path path;


    public GameObject debugsphere;
    [Header("Sight Settings")]
    public float SightDistance = 20f;
    public float FieldOfView = 100f;
    public float eyeHeight;
    [Header("Weapon Value")]
    public Transform gunBarrel;
    [Range(0.1f, 10f)]
    public float fireRate;
    [SerializeField]
    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
        debugsphere.transform.position = lastKnownPosition;
    }
    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < SightDistance)
            {
                Vector3 direction = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angle = Vector3.Angle(direction, transform.forward);
                if (angle >= -FieldOfView && angle <= FieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), direction);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, SightDistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            return true;
                        }
                    }
                    Debug.DrawRay(ray.origin, ray.direction * SightDistance, Color.red);
                }
            }
        }
        return false;
    }

    private void Die()
    {
        // Implement your death logic here
        // For example, you could play a death animation or destroy the enemy object
        ScoreManager.instance.AddScore(50);

        Destroy(gameObject);
    }
}

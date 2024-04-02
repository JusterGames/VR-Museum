using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAndChase : MonoBehaviour
{
    public Transform[] patrolPoints; // An array of patrol points in your scene.
    public Transform player; // Reference to the player's transform.
    public float patrolSpeed = 3.0f;
    public float chaseSpeed = 6.0f;
    public float chaseDistance = 10.0f; // The distance at which the agent starts chasing the player.
    public float stoppingDistance = 1.0f; // The distance at which the agent stops when attacking.

    private NavMeshAgent navMeshAgent;
    private int currentPatrolPoint = 0;
    private bool isChasing = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetNextPatrolPoint();
    }

    void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void SetNextPatrolPoint()
    {
        navMeshAgent.speed = patrolSpeed;
        navMeshAgent.stoppingDistance = 0.0f;
        navMeshAgent.SetDestination(patrolPoints[currentPatrolPoint].position);

        currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Length;
    }

    void Patrol()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
        {
            SetNextPatrolPoint();
        }

        if (CanSeePlayer())
        {
            StartChasing();
        }
    }

    void StartChasing()
    {
        isChasing = true;
        navMeshAgent.speed = chaseSpeed;
        navMeshAgent.stoppingDistance = stoppingDistance;
    }

    void ChasePlayer()
    {
        if (CanSeePlayer())
        {
            navMeshAgent.SetDestination(player.position);

            if (Vector3.Distance(transform.position, player.position) <= stoppingDistance)
            {
                // Attack or perform other actions here.
                // You can add your own logic to handle attacking.
            }
        }
        else
        {
            isChasing = false;
        }
    }

    bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) <= chaseDistance)
        {
            RaycastHit hit;
            if (Physics.Linecast(transform.position, player.position, out hit))
            {
                if (hit.transform == player)
                {
                    return true;
                }
            }
        }
        return false;
    }
}

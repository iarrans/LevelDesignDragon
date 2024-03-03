using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{

    public enum State { patrulla, perseguir }

    public State initialState;

    public State actualState;

    public List<Transform> wayPoints;

    public int indexNextWaypoint;

    public float minDistance;

    public float range;

    NavMeshAgent agent;

    public Transform playerTransform;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        actualState = initialState;
    }

    private void Update()
    {
        switch (actualState)
        {
            case State.patrulla:
                if (Vector3.Distance(transform.position, wayPoints[indexNextWaypoint].position) < minDistance)
                {
                    indexNextWaypoint++;
                    if (indexNextWaypoint >= wayPoints.Count)
                    {
                        indexNextWaypoint = 0;
                    }
                }

                agent.SetDestination(wayPoints[indexNextWaypoint].position);

                break;

            case State.perseguir:
                agent.SetDestination(playerTransform.position);

                if (Vector3.Distance(transform.position, playerTransform.position) > range)
                {
                    actualState = State.patrulla;
                }
                break;
        }
    }
}

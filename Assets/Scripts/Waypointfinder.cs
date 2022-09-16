using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Waypointfinder : MonoBehaviour
{

    public Transform[] waypoints;
    private int desPoint = 0;
    private NavMeshAgent agent;




    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        gotopoint();
    }
    void gotopoint()
    {
        if (waypoints.Length == 0)
            return;
        agent.destination = waypoints[desPoint].position;

    }
    
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            gotopoint();
    }
}

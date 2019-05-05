using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AImoveToPlayer : MonoBehaviour
{
    public Transform goal;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }
    private void Update()
    {
        
        agent.destination = goal.position;
    }

}

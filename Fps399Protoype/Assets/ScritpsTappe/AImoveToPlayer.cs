using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AImoveToPlayer : MonoBehaviour
{
    public Transform goal;
    NavMeshAgent agent;
    [SerializeField] bool inactive;
    [SerializeField] Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        inactive = true;
        anim.enabled = false;
        agent = GetComponent<NavMeshAgent>();
        
    }
    private void Update()
    {
        if (inactive == false)
        agent.destination = goal.position;
    }
    public void ActivateAttack()
    {
        anim.enabled = true;
        inactive = false;
    }

}

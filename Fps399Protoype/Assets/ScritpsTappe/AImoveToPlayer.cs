using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Ai behaviour made for eneies that move to player and attacks in close combat.
public class AImoveToPlayer : MonoBehaviour
{
    public Transform goal;
    NavMeshAgent agent;
    [SerializeField] bool inactive;
    [SerializeField] Animator anim;

    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Player").transform;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Ai behaviour made for eneies that move to player and attacks in close combat.
public class AImoveToPlayer : MonoBehaviour
{
    public int health = 5;
    public Transform goal;
    NavMeshAgent agent;
    [SerializeField] bool inactive;
    [SerializeField] Animator anim;
    [SerializeField] AudioSource source;
    

    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        anim.enabled = false;
        inactive = true;
        anim.enabled = false;
        agent = GetComponent<NavMeshAgent>();
        source = GetComponent<AudioSource>();
        source.enabled = false;
        
    }//Initialize and sets to inactive

    private void Update()
    {
        if (inactive == false)
        agent.destination = goal.position;
    }//Sets player as destination and updates it.

    public void ActivateAttack()
    {
        anim.enabled = true;
        inactive = false;
        source.enabled = true;
    } //Gets activatet by TriggerOnEnter.cs

    public void TakeDamage(int amount)
    {
        print("-hp");
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }//Enemy takes damage.

    void Die()
    {
        Destroy(gameObject);
    }//Enemy dies
}

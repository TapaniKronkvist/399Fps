using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISpiderRanged : MonoBehaviour
{
    public int health = 5;
    public Transform goal;
    NavMeshAgent agent;
    [SerializeField] bool inactive;
    [SerializeField] bool lineOfSight;
    [SerializeField] Animator anim;
    [SerializeField] AudioSource source;
    [SerializeField] GameObject projectilePrefab;
    float range;
    float speed;
    [SerializeField] float rateOfFire;
    [SerializeField] Transform projectileStart;


    void Start()
    {
        range = 500.0f;
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        anim.enabled = false;
        inactive = true;
        anim.enabled = false;
        agent = GetComponent<NavMeshAgent>();
        source = GetComponent<AudioSource>();
        source.enabled = false;
        speed = 5.0f;
        rateOfFire = 3.0f;

    }//Initialize and sets to inactive

    private void Update()
    {
        if (rateOfFire > 0)
        {
            rateOfFire -= 1 * Time.deltaTime;
        }
        if (rateOfFire < 0)
        {
            rateOfFire = 3.0f;
        }
        if (inactive == false && lineOfSight == false)
        {
            agent.speed = 8.0f;
            agent.destination = goal.position;
            anim.enabled = true;

            Vector3 targetDir = goal.position - transform.position;

            // The step size is equal to speed times frame time.
            float step = speed * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);

            // Move our position a step closer to the target.
            transform.rotation = Quaternion.LookRotation(newDir);
        }
        

        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            
            if (hit.collider.tag == "Player")
            {
                lineOfSight = true;
                Debug.Log("Player Found");
            }
            
            
        }
        if (lineOfSight)
        {
            RangeAttack();
        }

            
    }//Sets player as destination and updates it if player not in line of sight. Else it starts to range attack

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

    void RangeAttack()
    {
        anim.enabled = false;
        agent.speed = 0;
        if (rateOfFire <= 1)
        {
            GameObject clone = Instantiate(projectilePrefab, projectileStart.transform.position, projectileStart.transform.rotation);
            clone.transform.Translate(transform.forward);
            print("Shooting player");
            rateOfFire = 3;
        }
        lineOfSight = false;
    }//Range attack 
}

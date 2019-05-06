using UnityEngine;
using UnityEngine.Events;

//Weapon class that shoot with raycast with rate of fire. Can hit and damagae spiderPrefab object.
public class GunAutomatic : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] int damage;
    [SerializeField] float range;
    [SerializeField] float rateOfFire;
    [SerializeField] float fireReady;
    [SerializeField] GameObject hitEffect;
    [SerializeField] float impactForce;
    
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera; ;
        fireReady = rateOfFire;
    } //Init camera and rate of fire

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (rateOfFire == fireReady)
            {
                rateOfFire--;
                Shoot();
            }
            
        } //shoot
        if (rateOfFire < fireReady)
        {
            rateOfFire -= Time.deltaTime;
        }//Rate of fire counter;
        if ( rateOfFire <= 0)
        {
            rateOfFire = fireReady;
        }//Reset fire rate
    } //Get input to shoot, activates rate of fire counter and resets it.

    void Shoot()
    {
        RaycastHit hit;
        Debug.Log("Shot");
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            if (hit.collider.tag == "Enemy")
            {
                AImoveToPlayer enemyHit = hit.transform.GetComponent<AImoveToPlayer>();
                enemyHit.TakeDamage(damage);
                Debug.Log("Hit enemy");
            }
            Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
        
    }//Raycast shooting, damage delt to AImoveToPlayer, also impacts anything with a rigidbody.
}

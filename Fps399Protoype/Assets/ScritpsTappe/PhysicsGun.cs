using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsGun : MonoBehaviour
{
    [SerializeField] float range = 5.0f;
    [SerializeField] Transform objectToHold;
    [SerializeField] Transform holdingOffset;
    public PhysicsGunOffsetCollider test;
    [SerializeField] bool offsetTest;
    public bool moving = false; //When moving object around
    public Collider col;

    private void Start()
    {
        offsetTest = test.failure;
    }
    void LateUpdate()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * range;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
        {
            if (hit.transform.tag == "moveable")
            {
                print("moveable in reach");
                objectToHold = hit.transform;
            }
        }
        Debug.DrawRay(transform.position, forward, Color.green);
    }
    void Update()
    {
        offsetTest = test.failure;

        if (Input.GetButton("Fire1") && objectToHold != null && moving == false && offsetTest == false) //Checking all parameters for picking up box 
        {
            print("picked box up");
            moving = true;
        }
        if (moving && offsetTest == false) //Carry Static Object
        {
            objectToHold.transform.position = holdingOffset.transform.position;
            col.transform.rotation = objectToHold.transform.rotation;
        }
        if (Input.GetButtonUp("Fire1")) //Release Static Object
        {
            col.transform.rotation = holdingOffset.transform.rotation;
            moving = false;
            objectToHold = null;
        }
        if (!moving)
        {
            offsetTest = false;
            objectToHold = null;
        }
    }

}

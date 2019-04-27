using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsGun : MonoBehaviour
{
    private float range = 5.0f;
    [SerializeField] private Transform objectToHold;
    [SerializeField] private Transform holdingOffset;
    Collider check;


    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * range;
        Debug.DrawRay(transform.position, forward, Color.green);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
        {
            if (hit.transform.tag == "moveable")
            {
                    objectToHold = hit.transform;
            }
        }
        

    }
    private void LateUpdate()
    {
        
        if (objectToHold != null)
        {
            
            if (Input.GetButton("Fire1"))
            {
                check = objectToHold.GetComponent<Collider>();
                objectToHold.transform.position = holdingOffset.transform.position;
                objectToHold.transform.rotation = holdingOffset.transform.rotation;
            }
        }
        else
        {
            objectToHold = null;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            objectToHold = null;
        }
        if (check == true)
        {
            objectToHold = null;
        }

    }
    private void OnCollisionEnter(Collision check)
    {
        objectToHold = null;
    }

}

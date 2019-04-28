using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsGunOffsetCollider : MonoBehaviour
{
    public PhysicsGun pg;
    public bool failure = false;
    [SerializeField] List<Collider> coll;
    
    void OnTriggerEnter(Collider other)
    {

        coll.Add(other);
        if (coll.Count > 1)
        {
            failure = true;
            coll.Clear();
        }

        print("Added to list");
    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "StaticObject")
        failure = true;
        print("hit static");
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "StaticObject")
            failure = false;
        print("hit static");
    }
    
    
}

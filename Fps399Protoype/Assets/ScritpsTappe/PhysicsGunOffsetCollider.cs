using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsGunOffsetCollider : MonoBehaviour
{
    public PhysicsGun pg;
    public bool failure = false;

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

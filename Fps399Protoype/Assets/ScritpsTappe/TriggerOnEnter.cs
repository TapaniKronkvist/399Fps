using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This class is attached to a object that reakts to the player. This uses a listener and 
activates method on the class being called. Set method in inspector. This class i 
modular and works on any non static object. Written by Tapani Kronkvist*/

public class TriggerOnEnter : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent RemoveBlockade; //Disable blockade call;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            RemoveBlockade.Invoke();
        }
    } //RemoveBlockade object is called and disabled via Blockade.Disable;

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*This class is attached to a object that reakts to the player. This uses a listener and 
activates method on the class being called. Set method in inspector. This class i 
modular and works on any non static object. Written by Tapani Kronkvist*/

public class TriggerOnEnter : MonoBehaviour
{
    public UnityEvent RemoveBlockade;//Call to disable;
    public UnityEvent ActivateEnemy;//Call to enable;
    public UnityEvent OpenDoor;//Call to open
    public UnityEvent ActivateBlockade;//Activates blockade
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            RemoveBlockade.Invoke();
            ActivateBlockade.Invoke();
            ActivateEnemy.Invoke();
            OpenDoor.Invoke();
            Destroy(gameObject);
        }
    } //RemoveBlockade object is called and disabled via Blockade.Disable;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a blockade in level and uses listener Use TriggerOnEnter.cs to make the call to Disable().
public class Blockade : MonoBehaviour
{
   public void Disable()
    {
        Destroy(gameObject);
    }//Destroy this game object.
}

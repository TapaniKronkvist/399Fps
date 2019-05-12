using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a blockade in level and uses listener Use TriggerOnEnter.cs to make the call to Disable().
public class Blockade : MonoBehaviour
{
    BoxCollider boxCollider;
    MeshRenderer mesh;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        mesh = GetComponent<MeshRenderer>();
    }
    public void Disable()
    {
        Destroy(gameObject);
    }//Destroy this game object.
    public void Enable()
    {
        if (boxCollider.enabled == false)
        {
            boxCollider.enabled = true;
        }
        if (mesh.enabled == false)
        {
            mesh.enabled = true;
        }
    }
}

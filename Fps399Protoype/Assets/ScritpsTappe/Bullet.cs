using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bullet hit logic
public class Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "StaticObject")
        {
            print("Bullet hit static object");
            Destroy(gameObject);
        }
        if (hit.gameObject.tag == "Enemy")
        {
            print("Bullet hit Enemy");
            Destroy(gameObject);
        }
    }
}

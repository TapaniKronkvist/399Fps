using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponLaser : MonoBehaviour
{
    LineRenderer line;
    public PhysicsGun modeReference;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && modeReference.moveMode == true)
        {
            StopCoroutine("FireLaser");
            StartCoroutine("FireLaser");
        }
    }

    IEnumerator FireLaser()
    {
        line.enabled = true;
        while (Input.GetButton("Fire1"))
        {
            line.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, Time.time);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            line.SetPosition(0, ray.origin);

            if (Physics.Raycast(ray, out hit, 20))
            {
                line.SetPosition(1, hit.point);
            }
            else
            {
                line.SetPosition(1, ray.GetPoint(20));
            }
            yield return null;
        }

        line.enabled = false;
    }
}

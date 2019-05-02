using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class controlls item moving and charge shots. This class is referencing PhysicsGunOffsetCollider class.
public class PhysicsGun : MonoBehaviour
{
    //Moving objects Variables
    [SerializeField] float range = 3.0f;
    public Transform objectToHold; //Actual reference to object being moved
    [SerializeField] Transform holdingOffset; //Where box i held
    public PhysicsGunOffsetCollider test; //Reference to class
    [SerializeField] bool offsetTest; //Reference to to other class
    public bool moving = false; //When moving object around
    public Collider col;
    public bool moveMode;
    
    //Chargin shot var
    [SerializeField] private int magazine;
    [SerializeField] float counter;
    private float maxCounter;
    public TMPro.TextMeshProUGUI displayText;

    //Shooting var 
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletEmitter;
    [SerializeField] float bulletSpeed;

    private void Start()
    {
        moveMode = true;
        magazine = 0;
        maxCounter = counter;
        offsetTest = test.failure;
        displayText.text = magazine.ToString();
        
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
    } //Raycast.
    void Update()
    {
        offsetTest = test.failure;
        if (moveMode) //Display
        {
            displayText.text = $"Move Mode\n\n{magazine}"; //Show mag size
        } //Display move mode and ammo on display.
        else
        {
            displayText.text = $"Shoot Mode\n\n{magazine}"; //Show mag size
        } //Display shoot mode and ammo on display.

        if (Input.GetButton("Fire1") && objectToHold != null && moving == false && offsetTest == false && moveMode) //Checking all parameters for picking up box 
        {
            print("picked box up");
            moving = true;
        }
        if (moving && offsetTest == false && objectToHold != null) //Carry Static Object
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
        if (moving == true && Input.GetButton("Fire2") && moveMode)
        {
            CharginShoot();
        } //Charging to desolve object.
        if (!moving)
        {
            offsetTest = false;
            objectToHold = null;
        } //Reset if object dropped.
        if (Input.GetKeyDown(KeyCode.E)) //Changing mode Key will change to input settings later
        {
            SwitchMode();
        }//Switching firemode
        if (Input.GetButtonDown("Fire1") && moveMode == false)
        {
            Fire();
        } //Fire weapon in Shoot mode.
    }
    void CharginShoot()
    {
        if (moving)
        {
            counter -= 1.0f * Time.deltaTime;
            Debug.Log(counter);
            if (counter <= 0.0f)
            {
                if (objectToHold != null)
                {
                    magazine++;
                    Destroy(objectToHold.gameObject);
                    objectToHold = null;
                    moving = false;
                    counter = maxCounter;
                }
                
                counter = maxCounter;

            }
            print("Chargin shoot");
            if (!moving || objectToHold == null)
            {
                counter = maxCounter;
                return;
            }
        }
        else
        {
            counter = maxCounter;
            return;
        }
    } //Chargin to desolve object for ammo.
    void SwitchMode()
    {
        if (moveMode)
        {
            moveMode = false;
        }
        else
        {
            moveMode = true;
        }
    } //Switch firemode. 
    void Fire()
    {
        if (magazine > 0)
        {
            GameObject bulletClone;
            bulletClone = Instantiate(bulletPrefab, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;
            Rigidbody newBulletBody;
            newBulletBody = bulletClone.GetComponent<Rigidbody>();
            newBulletBody.AddForce(transform.forward * bulletSpeed);

            print("Shot fired");
            magazine--;
        }
    } //Shooting desolved object.
}

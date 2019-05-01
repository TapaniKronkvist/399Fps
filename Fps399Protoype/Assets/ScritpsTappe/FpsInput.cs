using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/Fps Input")]
public class FpsInput : MonoBehaviour
{
    public enum States { moving, interacting}
    States state;

    public float speed = 6.0f, dash, gravity, jumpForce = 25.0f; //Normal speed, dash speed, gravity force;
    [SerializeField] float gravityMultiplier = 0.7f;
    [SerializeField] private float currentSpeed; //Calculated speed and true speed of character
    private CharacterController _charController;

	// Use this for initialization
	void Start ()
    {
        state = States.moving;
        _charController = GetComponent<CharacterController>();
        speed = 6.0f;
        currentSpeed = speed; //Sets speed to normal
        
	}

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case States.moving:
                Moving();
                break;
            case States.interacting:
                Interacting();
                break;
        }
	}
    void Moving()
    {
        //Movement
        float deltaX = Input.GetAxis("Horizontal") * currentSpeed;
        float deltaZ = Input.GetAxis("Vertical") * currentSpeed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        if (Input.GetAxis("Jump") != 0 && _charController.isGrounded)
        {
            gravity = jumpForce;
        }

        movement = Vector3.ClampMagnitude(movement, currentSpeed);

        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
        Falling();
    }

    void Falling()
    {
        if(!_charController.isGrounded)
        {
            gravity -= gravityMultiplier;
        }
    }

    void Interacting()
    {
        print("Interacting");
    }
}

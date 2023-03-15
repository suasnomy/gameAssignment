using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 0.5f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private float animationDuration = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time < animationDuration)
        {
            controller.Move(Vector3.forward*speed*Time.deltaTime);
            return;
        }


        moveVector = Vector3.zero;
        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else {
            verticalVelocity -= gravity * Time.deltaTime; 
        }
        //calculate x , y and z. x is left and right, y is up and down , z is forward and backward.
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }
}

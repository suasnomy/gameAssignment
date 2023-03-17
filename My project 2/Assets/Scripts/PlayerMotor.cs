using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public GameObject cam, leftPosition, rightPosition, playerPrefabs;
    private CharacterController controller;
    private float speed = 5f;
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

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Hello");
    //    if (collision.gameObject.tag == "wall")
    //    {
    //        // Handle collision with wall here
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Inside collision detection.");
        if(other.CompareTag("wall"))
        {
            Debug.Log("Game Over");
            transform.gameObject.SetActive(false);
            for (int i = 0; i < 10; i++)
            {

            Instantiate(playerPrefabs, transform.position, Quaternion.identity);
            }

        }

        if(other.CompareTag("end"))
        {
            Debug.Log("Congratulations");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            Debug.Log("You Died");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //for (int i = 0; i < 100; i++)
            //{
            //    //Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f)); // Change the ranges to specify where you want the prefabs to spawn
            //    //Quaternion spawnRotation = Quaternion.identity; // Set the rotation to identity to keep it upright
            //    //Instantiate(playerPrefabs, spawnPosition, spawnRotation);
            //    Instantiate(playerPrefabs, transform.position, Quaternion.identity);
            //}

        }

        if(other.CompareTag("end"))
        {
            Debug.Log("Congratulations");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

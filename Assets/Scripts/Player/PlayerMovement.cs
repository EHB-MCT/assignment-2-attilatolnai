using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class handles player movement using Rigidbody2D physics
public class PlayerMovement : MonoBehaviour
{
    //The movement speed of the player
    public float moveSpeed;
    //Refer to the Rigidbody2D connected to the player asset
    public Rigidbody2D rigidbody;
    //The current direction of the player asset
    private Vector2 moveDirection;

    public circleItem ci;

    //Called every frame. Processes player input and updates movement direction.
    void Update(){
        ProcessInputs();
    }

    //Called at fixed intervals. Moves the player based on the current movement direction.
    void FixedUpdate()
    {
        Move();
    }

    //Checks player input from the keyboard to see which direction the user wants to go.
    void ProcessInputs(){
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");
        // Normalizing the direction ensure consistent movement speed in all directions.
        moveDirection = new Vector2(movementX, movementY).normalized;
    }

    //Applies the calculated movement.
    void Move(){
        rigidbody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    //When the player collides with an item
    void OnTriggerEnter2D(Collider2D other)
    {
        //If the items has the "Circle" tag assigned to it, add one to the circle counter and destroy it.
        if (other.gameObject.CompareTag("Circle"))
        {
            Destroy(other.gameObject);
            ci.circleCount++;
        }

        if (other.gameObject.CompareTag("StartArea"))
        {
            if(ci.circleCount > 0)
            {
                ci.startAreaText.text = "Circles Collected: " + ci.circleCount.ToString();
                ci.startAreaText.gameObject.SetActive(true);
            }
        }
    }
}

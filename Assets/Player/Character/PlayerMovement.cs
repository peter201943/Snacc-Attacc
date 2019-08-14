

//Declarations import objects from Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//PlayerMovement handles moving the player
public class PlayerMovement : MonoBehaviour
{


    //VARIABLES
    //Variables are used in methods
    public float Speed = 6f;
    Vector3 Movement;
    Animator PlayerAnimator;
    Rigidbody PlayerRigidbody;
    int FloorMask;
    float CameraRayLength = 100f;


    //AWAKE
    //Awake is called regardless of assignment
    //Binds components
    void Awake()
    {
        //Binding Player Components to Script
        FloorMask = LayerMask.GetMask ("CameraFloor");
        PlayerAnimator = GetComponent <Animator> ();
        PlayerRigidbody = GetComponent <Rigidbody> ();
    }


    //FIXEDUPDATE
    //Fixed Update is called once per Physics frame
    //Binds input and calls moves to player
    void FixedUpdate()
    {
        //Raw Input for Snappy Movement
        //Horizontal maps to the "A" and "D" keys
        //Vertical maps to the "W" and "S" keys
        float H = Input.GetAxisRaw("Horizontal");
        float V = Input.GetAxisRaw("Vertical");
        //Pass input off to individual "movers"
        Move(H, V);
        Turn();
        Animate(H, V);
    }


    //MOVE
    //Move is called from FixedUpdate
    //Moves the Player
    void Move (float H, float V)
    {
        //Point Vector along X, Y, Z Input
        Movement.Set(H, 0f, V);
        //Set Magnitude per frame at the correct Speed
        Movement = Movement.normalized * Speed * Time.deltaTime;
        //Apply Vector to Player at Player's position
        PlayerRigidbody.MovePosition(transform.position + Movement);
    }


    //TURN
    //Turn is called from FixedUpdate
    //Sets the Player Model's Rotation
    void Turn()
    {
        //Creates and binds a ray to the Mouse
        Ray CameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Gives information to other scripts
        RaycastHit FloorHit;
        //Casts the ray and checks if it hits
        if (Physics.Raycast(CameraRay, out FloorHit, CameraRayLength, FloorMask))
        {
            //Distance from player to aimpoint
            Vector3 PlayerToMouse = FloorHit.point - transform.position;
            //Prevent Player from rotating up and down
            PlayerToMouse.y = 0f;
            //Set direction of player to mouse
            Quaternion NewRotation = Quaternion.LookRotation(PlayerToMouse);
            //Move the player model by the angle
            PlayerRigidbody.MoveRotation (NewRotation);
        }
    }


    //ANIMATE
    //Animate is called from FixedUpdate
    //Sets the Player Animation's state
    void Animate(float H, float V)
    {
        //Create a condition for walking
        bool Walking = false;
        //If not moving in either direction set walking to true
        if (H != 0f && V != 0f) Walking = true;
        //Assign state to Animation
        PlayerAnimator.SetBool("IsWalking", Walking);
    }

}

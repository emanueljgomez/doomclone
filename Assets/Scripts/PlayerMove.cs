using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    [SerializeField] private float playerSpeed = 20f;
    [SerializeField] private CharacterController myCC;
    [SerializeField] private Animator camAnim;
    [SerializeField] private bool isWalking;

    [SerializeField] private Vector3 inputVector;
    [SerializeField] private Vector3 movementVector;
    [SerializeField] private float myGravity = -10f;

    void Start()
    {
        myCC = GetComponent<CharacterController>();
    }

    void Update()
    {
       GetInput();
       MovePlayer();
       CheckForHeadBob();

       // Updates boolean Animation Parameter based on movement detected
       // by 'CheckForHeadBob()' in order to trigger animation
       camAnim.SetBool("isWalking", isWalking);
    }

    void GetInput()
    {   
        // Generates movement vector based on keyboard input
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);

        // Improves movement vector by adding gravity calculation
        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);
    }

    void MovePlayer()
    {
        myCC.Move(movementVector * Time.deltaTime);
    }

    void CheckForHeadBob()
    {
        if (myCC.velocity.magnitude > 0.1f)
        {
            isWalking = true;
        } else
        {
            isWalking = false;
        }
    }

}

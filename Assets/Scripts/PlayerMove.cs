using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    [SerializeField] private float playerSpeed = 20f;
    [SerializeField] private float momentumDamping = 5f;
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

       // Updates boolean Animation Parameter based on movement detected
       // by 'CheckForHeadBob()' in order to trigger animation
       camAnim.SetBool("isWalking", isWalking);
    }

    void GetInput()
    {   
        // If player holds down W-A-S-D, then give -1, 0, 1
        if (
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D)
            )
        {   
            // Generates movement vector based on keyboard input
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);

            isWalking = true; // Triggers head bob animation on player movement

        } else
        {   
            // Adds momentum to player movement:
            // If player is NOT holding down W-A-S-D then give
            // last checked InputVector and lerp it towards zero
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentumDamping * Time.deltaTime);

            isWalking = false; // Stops head bob animation
        }        

        // Improves movement vector by adding gravity calculation
        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);
    }

    void MovePlayer()
    {
        myCC.Move(movementVector * Time.deltaTime);
    }

}

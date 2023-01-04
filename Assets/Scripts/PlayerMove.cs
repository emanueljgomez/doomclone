using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    [SerializeField] private float playerSpeed = 20f;
    [SerializeField] private CharacterController myCC;

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
    }

    void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);

        // Movement vector + Gravity vector
        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);
    }

    void MovePlayer()
    {
        myCC.Move(movementVector * Time.deltaTime);
    }


}
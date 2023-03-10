using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1.5f;
    [SerializeField] private float smoothing = 1.5f;

    [SerializeField] private float xMousePos;
    [SerializeField] private float smoothedMousePos;

    [SerializeField] private float currentLookingPos;

    void Start()
    {
        // Locks mouse cursor and makes it invisible:
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }

    void GetInput()
    {   
        // Obtains mouse horizontal input
        xMousePos = Input.GetAxisRaw("Mouse X");
    }

    void ModifyInput()
    {   
        // Smoothes mouse input
        xMousePos *= sensitivity * smoothing;
        smoothedMousePos = Mathf.Lerp(smoothedMousePos, xMousePos, 1f / smoothing);
    }

    void MovePlayer()
    {
        // Calculates player move direction based on mouse position and rotation
        currentLookingPos += smoothedMousePos;
        transform.localRotation = Quaternion.AngleAxis(currentLookingPos, transform.up);
    }

}

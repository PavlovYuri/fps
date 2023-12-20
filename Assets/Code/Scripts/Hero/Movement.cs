using System.Collections;
using System.Collections.Generic;
//using UnityEditor.U2D;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    private float speed = 6.0f;
    private CharacterController characterController;
    private float gravity = -9.8f; 


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10.0f;
        } else {
            speed = 6.0f;
        }
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed) * Time.deltaTime;
        movement.y = gravity;
        movement = transform.TransformDirection(movement);

        characterController.Move(movement);
    }
    
}

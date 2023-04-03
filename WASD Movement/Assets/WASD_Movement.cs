using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_Movement : MonoBehaviour
{
    // make the player move using WASD. the player has a player controller and the ground is a square with a rigid body and a collider

    public float maxSpeed = 0.01f;

    public float acceleration = 0.00005f;

    private float verticalSpeed = 0.0f;
    private float horizontalSpeed = 0.0f;



    void Update()
    {
        Vector3 pos = transform.position;

        bool bothVerticalKeysPressed = Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S);
        bool bothVerticalKeysReleased = !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S);
        if(bothVerticalKeysPressed || bothVerticalKeysReleased)
        {
            if(verticalSpeed > 0)
            {
                verticalSpeed -= acceleration;
                if(verticalSpeed < 0)
                {
                    verticalSpeed = 0;
                }
            }
            else if(verticalSpeed < 0)
            {
                verticalSpeed += acceleration;
                if(verticalSpeed > 0)
                {
                    verticalSpeed = 0;
                }
            }
        }
        else if(Input.GetKey(KeyCode.W))
        {
            if(verticalSpeed < maxSpeed)
            {
                verticalSpeed += acceleration;
                
            }
            if(verticalSpeed > maxSpeed)
            {
                verticalSpeed = maxSpeed;
                Debug.Log("max speed reached");
            }
        }
        else
        {
            if(verticalSpeed > -maxSpeed)
            {
                verticalSpeed -= acceleration;
                if(verticalSpeed < -maxSpeed)
                {
                    verticalSpeed = -maxSpeed;
                }
            }
        }

        bool bothHorizontalKeysPressed = Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D);
        bool bothHorizontalKeysReleased = !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D);

        if(bothHorizontalKeysPressed || bothHorizontalKeysReleased)
        {
            if(horizontalSpeed > 0)
            {
                horizontalSpeed -= acceleration;
                if(horizontalSpeed < 0)
                {
                    horizontalSpeed = 0;
                }
            }
            else if(horizontalSpeed < 0)
            {
                horizontalSpeed += acceleration;
                if(horizontalSpeed > 0)
                {
                    horizontalSpeed = 0;
                }
            }
        }
        else if(Input.GetKey(KeyCode.D))
        {
            if(horizontalSpeed < maxSpeed)
            {
                horizontalSpeed += acceleration;
                if(horizontalSpeed > maxSpeed)
                {
                    horizontalSpeed = maxSpeed;
                }
            }
        }
        else
        {
            if(horizontalSpeed > -maxSpeed)
            {
                horizontalSpeed -= acceleration;
                if(horizontalSpeed < -maxSpeed)
                {
                    horizontalSpeed = -maxSpeed;
                }
            }
        }

        if(verticalSpeed > maxSpeed)
            verticalSpeed = maxSpeed;
        pos.x += horizontalSpeed;
        pos.y += verticalSpeed;

        transform.position = pos;
    }
    
}

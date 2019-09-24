using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    public Vector3 direction;

    

    public void FixedUpdate()
    {

        float h = variableJoystick.Horizontal;//thies work with WASD or arrow keys + other things unity can use, gamepad etc..
        float v = variableJoystick.Vertical;
        if (v != 0 || h != 0)
        {// if we are getting inputs, form -1 to 1, 0=no input
            
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        else
        {
            rb.velocity = rb.velocity * 0.9f;
        }
        
    }
}
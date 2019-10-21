using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleJoystick : MonoBehaviour
{
    JoystickController joystickController;
    public GameObject JoystickGameOBJ;
    
    void Start()
    {
        joystickController = GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickController>();
        JoystickGameOBJ = GameObject.FindGameObjectWithTag("JoystickOnlyImage");
    }

    void Update()
    {
        if (joystickController.usingJoyStick)
        {
            JoystickGameOBJ.SetActive(false);
        }
        if (joystickController.usingJoyStick == false)
        {
            JoystickGameOBJ.SetActive(true);
        }
    }
}

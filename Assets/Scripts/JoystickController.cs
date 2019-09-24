using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class JoystickController : MonoBehaviour
{
    #region Variable Llamada de ataque
    public WeaponCol weaponCol;
    #endregion

    #region Variables Movimiento Personaje (Joystick)

    [Header("VARIABLES JoyStick Izquierdo")]
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    public Vector3 direction;

    #endregion

    #region Variables Movimiento arma

    [Header("VARIABLES JoyStick Derecho")]
    public Button JButton;
    public GameObject arma;
    public Animator animator;
    public bool AttackOn = false;

    #endregion
    public void Start()
    {
        //JButton.onClick.AddListener(Attack);

    }

    public void Update()
    {


    }

    public void FixedUpdate()
    {
        #region Movimiento Personaje (no tocar)


        float h = variableJoystick.Horizontal;//thies work with WASD or arrow keys + other things unity can use, gamepad etc..
        float v = variableJoystick.Vertical;
        if (v != 0 || h != 0)
        {// if we are getting inputs, form -1 to 1, 0=no input

            if (v >= 0.5f || v <= -0.5f || h >= 0.5f || h <= -0.5f)
            {
                animator.SetBool("Running", true);
            }
            else
            {
                animator.SetBool("Walking", true);
                animator.SetBool("Running", false);

            }
            //animator.SetBool("Running", true);
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            //transform.rotation = Quaternion.LookRotation(direction);
            transform.localRotation = Quaternion.LookRotation (direction);

            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        else
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Running", false);
            rb.velocity = rb.velocity * 0.8f;
            if (rb.velocity.magnitude <= 0.1f)
            {
               
            }
        }

        #endregion 

        #region Movimiento Arma
        //Rigidbody armaRB = arma.GetComponent<Rigidbody>();
        //armaRB.velocity = Vector3.right * speed;

        #endregion
    }

    public void Attack()
    {
        Rigidbody armaRB = arma.GetComponent<Rigidbody>();
    }
    public void Impact()
    {
        weaponCol.ActiveCol();
    }
    public void ColOFF()
    {
        weaponCol.DesactiveCol();
    }
}

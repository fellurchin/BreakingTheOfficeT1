using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyEnemy : MonoBehaviour
{

    public ShowDataHUD showDataHUD;
    public JoystickController joystickController;
    public Collider Arma;
    

    public bool EnemyCollided_T1 = false;

    void Start()
    {
        joystickController.JButton.onClick.AddListener(AttackV);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AttackV();
        }
    }

   
    public void AttackV()
    {
        joystickController.animator.SetTrigger("Attack1");
    }
  
    
}

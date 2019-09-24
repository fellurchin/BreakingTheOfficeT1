using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class WeaponCol : MonoBehaviour
{
    public ShowDataHUD showDataHUD;
    public DestroyEnemy destroyEnemy;
    public JoystickController joystickController;

    Collider SelfCollider;
    public int enemyCount;
    

    public float counter = 0;
    float maxTime =2;

    bool counterActive = false;

    void Start()
    {
        joystickController.JButton.onClick.AddListener(ActiveCounter_);
        SelfCollider = GetComponent<Collider>();
        SelfCollider.enabled = false;
    }

    void Update()
    {
        if (counterActive)
        {
            counter += Time.deltaTime;
            if (counter > 0.19f )
            {
                SelfCollider.enabled = true;
                
            }
            if (counter > 0.30)
            {
                SelfCollider.enabled = false;
                counter = 0;
                counterActive = false;
            }
        }

        

        
        
    }

    void OnTriggerEnter(Collider Col)
    {
        
        if (Col.gameObject.tag == "Enemy")
        {
            Col.gameObject.GetComponent<EnemyHealth>().RemoveHealth(35);
        }

    }
    public void ActiveCounter_()
    {
    }
    public void ActiveCol()
    {
        SelfCollider.enabled = true;

    }
    public void DesactiveCol()
    {
        SelfCollider.enabled = false;

    }
}

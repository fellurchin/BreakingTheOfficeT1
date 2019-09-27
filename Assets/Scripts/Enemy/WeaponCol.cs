using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class WeaponCol : MonoBehaviour
{
    public ShowDataHUD showDataHUD;
    public DestroyEnemy destroyEnemy;
    public JoystickController joystickController;
    GunController gunController;

    public int HealthToRemove = 35;

    Collider SelfCollider;
    public int enemyCount;

    public GameObject Point_OBJ;
    

    public float counter = 0;
    float maxTime =2;

    bool counterActive = false;

    public void Start()
    {
        gunController = GameObject.FindGameObjectWithTag("GunController").GetComponent<GunController>();
        joystickController.JButton.onClick.AddListener(ActiveCounter_);
        GetComponent<Collider>();
        SelfCollider = gameObject.GetComponent<Collider>();
        if (SelfCollider != null)
        {
            Debug.Log("listo");
        }
        SelfCollider.enabled = false;
        
    }

    public void Update()
    {
        SelfCollider = Point_OBJ.GetComponent<Collider>();
        
    }

    void OnTriggerEnter(Collider Col)
    {
        
        if (Col.gameObject.tag == "Enemy")
        {
            Col.gameObject.GetComponent<EnemyHealth>().RemoveHealth(HealthToRemove);
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

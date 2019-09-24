using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public WeaponCol weaponCol;
    public ShowDataHUD showDataHUD;
    GameObject CanvasOBJ;

    public GameObject[] cubes;
    public Rigidbody[] cubesRB;

    private float explosionForce = 10;
    private float explosionRadius = 10;

    public float maxHealth;
    public float health;
    public int pointsToGive;
    public GameObject healthBarCC;

    public RectTransform healthBar;
    public void Start()
    {
        health = maxHealth;
        CanvasOBJ = GameObject.Find("Canvas");
        showDataHUD = CanvasOBJ.GetComponent<ShowDataHUD>();
        
        //cubesRB = cubes[].GetComponent<Rigidbody>();

        

        //HealthBarCanvas = healthBarCC.GetComponent<Canvas>();
    }
    void FixedUpdate()
    {
        if (health == maxHealth)
        {
            healthBarCC.SetActive(false);
        }
        else
        {
            healthBarCC.SetActive(true);
        }


    }

    public void RemoveHealth(float dmgAmount)
    {
        health -= dmgAmount;

        if (health <= 10)
        {
            

        }
        if (health <= 0)
        {
            showDataHUD.AddToScore(pointsToGive);
            showDataHUD.enemyCountS += 3;
            Destroy(gameObject);
        }
        healthBar.sizeDelta = new Vector2(health * 2, healthBar.sizeDelta.y);
    }
    
    

}

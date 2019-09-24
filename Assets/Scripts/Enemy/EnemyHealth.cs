using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public bool isAWall = false;
    public GameObject GoodWall;
    public GameObject BadWall;
    private Collider thisCollider;
    private bool CountEnemy = true;


    WeaponCol weaponCol;
    public ShowDataHUD showDataHUD;
    GameObject ShowDataHudOBJ;
    public Explosion explosion;

    public GameObject[] cubes;
    public Rigidbody[] cubesRB;

    private float explosionForce = 10;
    private float explosionRadius = 10;

    public float maxHealth;
    public float health;
    public int pointsToGive;
    public GameObject healthBarCC;

    public RectTransform healthBar;
    public RectTransform healthBarBG;
    public void Start()
    {
        health = maxHealth;
        //weaponCol = GameObject.Find("Point").GetComponent<WeaponCol>();
        weaponCol = GameObject.FindGameObjectWithTag("Point").GetComponent<WeaponCol>();
        ShowDataHudOBJ = GameObject.Find("ShowDataHud");
        showDataHUD = ShowDataHudOBJ.GetComponent<ShowDataHUD>();

        thisCollider = gameObject.GetComponent<Collider>();


        //cubesRB = cubes[].GetComponent<Rigidbody>();


        healthBarBG.sizeDelta = new Vector2(health * 2, healthBar.sizeDelta.y);
        //HealthBarCanvas = healthBarCC.GetComponent<Canvas>();
    }
    void Update()
    {
        //weaponCol = GameObject.FindGameObjectWithTag("Point").GetComponent<WeaponCol>();
        if (health <= 0)
        {
            
            if (CountEnemy)
            {
                showDataHUD.AddToScore(pointsToGive);
                showDataHUD.enemyCountS += 1;
                CountEnemy = false;
            }


            if (isAWall)
            {
                ChangeWalls();
                explosion.ExplodeAct = true;
                //explosion.ExplodeAct = true;
            }
            else
            {
                explosion.ExplodeAct = true;
                if (gameObject.tag != "DestructibleWall")
                {
                    Destroy(gameObject, 0.5f);
                }
               
            }
        }
        

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
        healthBar.sizeDelta = new Vector2(health * 2, healthBar.sizeDelta.y);
    }

    public void ChangeWalls()
    {
        GoodWall.SetActive(false);
        healthBarCC.SetActive(false);
        thisCollider.enabled = false;
        
        BadWall.SetActive(true);

    }
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public bool countAsDestroyed = true;

    [Header("Variables de las paredes")]
    [SerializeField] bool isAWall = false;
    public GameObject GoodWall;
    public GameObject BadWall;
    private Collider thisCollider;
    private bool CountEnemy = true; //used to identify which GO give points to player
    
    WeaponCol weaponCol;
    ShowDataHUD showDataHUD;
    GameObject ShowDataHudOBJ;

    [Header("Objetos Explosion")]
    public Explosion explosion;
    public GameObject[] cubes;
    public Rigidbody[] cubesRB;

    public float maxHealth;
    public float health;
    public int pointsToGive;

    [Header("Objetos Barra De vida")]
    public GameObject healthBarCC;
    public RectTransform healthBar;
    public RectTransform healthBarBG;

    public void Start()
    {
        health = maxHealth;
        weaponCol = GameObject.FindGameObjectWithTag("Point").GetComponent<WeaponCol>();

        ShowDataHudOBJ = GameObject.Find("ShowDataHud");
        showDataHUD = ShowDataHudOBJ.GetComponent<ShowDataHUD>();

        thisCollider = gameObject.GetComponent<Collider>();

        healthBarBG.sizeDelta = new Vector2(health * 2, healthBar.sizeDelta.y);
    }
    void Update()
    {
        if (health <= 0)
        {
            if (CountEnemy)
            {
                showDataHUD.AddToScore(pointsToGive);
                if (countAsDestroyed)
                {
                    showDataHUD.enemyCountS += 1;
                }
                
                CountEnemy = false;
            }

            #region Sector of Destructible Walls

            if (isAWall)
            {
                ChangeWalls();
                explosion.ExplodeAct = true;
            }
            else
            {
                explosion.ExplodeAct = true;
                if (gameObject.tag != "DestructibleWall")
                {
                    Destroy(gameObject, 0.5f);
                }
            }
            #endregion

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

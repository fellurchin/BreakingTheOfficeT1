using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCheker : MonoBehaviour
{
    ShowDataHUD showDataHUD;
    [SerializeField] private int DestructionsToCheck;

    [SerializeField] bool UseDestructorCounter;
    // Start is called before the first frame update
    private void Awake()
    {
        showDataHUD = GameObject.Find("ShowDataHud").GetComponent<ShowDataHUD>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && UseDestructorCounter )
        {
            if (showDataHUD.enemyCountS >= DestructionsToCheck)
            {
                showDataHUD.wonMission = true;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && UseDestructorCounter)
        {
            if (showDataHUD.enemyCountS >= DestructionsToCheck)
            {
                showDataHUD.wonMission = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCheker : MonoBehaviour
{
    ShowDataHUD showDataHUD;
    [SerializeField] private int DestructionsToCheck;
    // Start is called before the first frame update
    private void Awake()
    {
        showDataHUD = GameObject.Find("ShowDataHud").GetComponent<ShowDataHUD>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            if (showDataHUD.enemyCountS >= DestructionsToCheck)
            {
                showDataHUD.wonMission = true;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (showDataHUD.enemyCountS >= DestructionsToCheck)
            {
                showDataHUD.wonMission = true;
            }
        }
    }
}

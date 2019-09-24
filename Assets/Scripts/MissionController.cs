using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI missionTitleTxt;
    [SerializeField] TextMeshProUGUI missionTxt;

    public ShowDataHUD showDataHUD;

    private string titleTextM1;
    private string textM1;
    void Start()
    {
        titleTextM1 = "VENDING MACHINES";

        textM1 = "In this mission, you must destroy as many Vending machines as you can," +
                 " the reason is that one of those hateful bikers owns the company. " +
                 "Enjoy it and press me when you're ready";
    }

    void Update()
    {
        missionTitleTxt.text = titleTextM1.ToString();
        missionTxt.text = textM1.ToString();
    }

    
}

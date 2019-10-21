using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MissionController : MonoBehaviour
{
    

    public TextMeshProUGUI missionTitleTxt;
    public TextMeshProUGUI missionTxt;
    public TextMeshProUGUI missionScore;

    public bool showM1 = false;
    public bool showM2 = false;


    public ShowDataHUD showDataHUD;

    string titleTextM1;
    string textM1;
    public string DestroyedObjsM1;
    public int maxObjectsM1 = 20;
    

    string titleTextM2;
    string textM2;
    public string DestroyedObjsM2;
    public int maxObjectsM2 = 20;


    void Start()
    {
        titleTextM1 = "INTRO MISSION";

        textM1 = "Follow the instructions, its the introduction for the game";

        if (PlayerPrefs.GetInt("Objs_1") != null)
        {
            DestroyedObjsM1 = PlayerPrefs.GetInt("Objs_1") + " / " + maxObjectsM1;
        }

        titleTextM2 = "THE OFFICE";

        textM2 = "Destroy each object of this site," +
                " and remember, look the time";

        if (PlayerPrefs.GetInt("Objs_2") != null)
        {
            DestroyedObjsM2 = PlayerPrefs.GetInt("Objs_2") + " / " + maxObjectsM2;
        }
    }

    void Update()
    {
        if (showM1)
        {
            if (missionTitleTxt != null)
            {
                missionTitleTxt.text = titleTextM1.ToString();
            }
            if (missionTxt != null)
            {
                missionTxt.text = textM1.ToString();

            }
            if (missionScore != null)
            {
                missionScore.text = DestroyedObjsM1.ToString();

            }
        }
        if (showM2)
        {
            if (missionTitleTxt != null)
            {
                missionTitleTxt.text = titleTextM2.ToString();
            }
            if (missionTxt != null)
            {
                missionTxt.text = textM2.ToString();

            }
            if (missionScore != null)
            {
                missionScore.text = DestroyedObjsM2.ToString();

            }
           

        }
    }

    
}

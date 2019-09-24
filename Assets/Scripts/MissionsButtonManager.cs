using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissionsButtonManager : MonoBehaviour
{
   

    MissionController missionController;
    DontDestroyOnLoad dontDestroyOnLoad;

    public GameObject Mission1OBJS;
    public GameObject Mission2OBJS;
    [Header("Botones Izquierda Derecha")]
    public Button leftButton;
    public Button rightButton;

    public GameObject[] MissionStateOP;
    public bool[] ActiveMission_;
    private bool nonActive = false;

    public GameObject IMG1;
    public GameObject IMG2;

    public int actualSate = 0;
    [Header ("Dinero Total")]
    public int tMoney;

    void Start()
    {
        actualSate = 0;
        leftButton.onClick.AddListener(Back);
        rightButton.onClick.AddListener(Next);

        missionController = GameObject.Find("MissionController").GetComponent<MissionController>();
    }

    void Update()
    {
        IMG1 = GameObject.Find("ImageM1");
        IMG2 = GameObject.Find("ImageM2");
        switch (actualSate)
        {
            case 0: missionController.showM1 = true;
                    missionController.showM2 = false;

                break;
            case 1:
                    missionController.showM1 = false;
                    missionController.showM2 = true;

                break;

            default:
                break;
        }
        #region Control De estados (actualState)

        if (actualSate < 0)
        {
            actualSate = 0;
        }
        if (actualSate >= MissionStateOP.Length)
        {
            actualSate = MissionStateOP.Length - 1;
        }
        #endregion

        #region Control Aparicion botones Izq Der
        //control Aparicion Botones

        if (actualSate == 0)
        {
            leftButton.interactable = false;
        }
        else leftButton.interactable = true;

        if (actualSate >= MissionStateOP.Length - 1)
        {
            rightButton.interactable = false;
        }
        else rightButton.interactable = true;
       
        //Cierre Aparicion Botones

        MissionStateOP[actualSate].SetActive(true);

        if (nonActive == true)
        {
            for (int i = 0; i < MissionStateOP.Length; i++)
            {
                MissionStateOP[i].SetActive(false);
                

            }
            nonActive = false;
        }
        #endregion

        Mission1OBJS = GameObject.Find("Scenery1");
        Mission2OBJS = GameObject.Find("Scenery2");

        

        if (dontDestroyOnLoad != null)
        {
            if (dontDestroyOnLoad.m1Active)
            {
                Mission1_V();
            }
            if (dontDestroyOnLoad.m2Active)
            {
                Mission2_V();
            }
        }
       

    }

    public void Back()
    {
        actualSate = actualSate - 1;
        nonActive = true;
    }

    public void Next()
    {
        actualSate = actualSate + 1;
        nonActive = true;
    }

    public void Mission1_V()
    {
        SceneManager.LoadScene(2);
        //missionController.missionTitleTxt.text = missionController.titleTextM1.ToString();
        //missionController.missionTxt.text = missionController.textM1.ToString();

        //Mission1OBJS.SetActive(true);
        //Mission2OBJS.SetActive(false);
    }
    public void Mission2_V()
    {
        SceneManager.LoadScene(3);
        //missionController.missionTitleTxt.text = missionController.titleTextM2.ToString();
        //missionController.missionTxt.text = missionController.textM2.ToString();

        //Mission1OBJS.SetActive(false);
        //Mission2OBJS.SetActive(true);
    }

}

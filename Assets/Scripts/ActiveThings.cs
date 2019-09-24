using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class ActiveThings : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dineroTotal;
    AddProduct addProduct;

    GunController gunController;
    MissionController missionController;
    GunUIcontroller gunUIcontroller;
    MissionsButtonManager missionsButtonManager;

    [Header("Modificar dinero")]
    public bool ModifyMoneyBool = false;
    public int MoneyToAdd;

    [Header("Boton Regresar")]
    public Button GoBackButton;

    [Header("Botones Misiones")]
    public Button[] BotonesMisionesARR;

    [Header("Botones Armas")]
    public Button[] BotonesArmasARR;

    [Header("Variables y objetos Misiones")]
    public GameObject MissionSelector;
    public int ActiveMission;

    [Header("Variables y objetos Armas")]
    public GameObject GunSelector;
    public int ActiveGun;

    [Header("Arrays Botones Comprado y no comprado")]
    public GameObject[] BuyedBTN;
    public GameObject[] NotBuyedBTN;

    [Header("Mision fue Seleccionada")]
    public int MisionSeleccionada;
    public bool MissionSelectedBool = false;

    [Header("Arma Seleccionada")]
    public int ArmaSeleccionada;
    public bool GunSelectedBool = false;

    [Header("Archivos Cada Arma")]
    public bool[] GunBuyed = new bool[6];

    public GameObject[] Armas;


    [Header("Dinero Total")]
    public int tMoney;
    public int Armanum_;

    public int FirstMoney;

    void Awake()
    {
        missionController       = GameObject.FindGameObjectWithTag("MissionController").GetComponent<MissionController>();
        gunUIcontroller         = GameObject.FindGameObjectWithTag("GunUIcontroller").GetComponent<GunUIcontroller>();
        missionsButtonManager   = GameObject.FindGameObjectWithTag("MissionButtonManager").GetComponent<MissionsButtonManager>();

        GoBackButton.onClick.AddListener(GoBackV);
    }
    void Start()
    {
        for (int i = 0; i < BotonesMisionesARR.Length; i++)
        {
            BotonesMisionesARR[i].onClick.AddListener(MissionSelected);
        }
        for (int i = 0; i < BotonesArmasARR.Length; i++)
        {
            BotonesArmasARR[i].onClick.AddListener(GunSelected);
        }
    }

    public void GoBackV()
    {
        MissionSelectedBool = false;
        GunSelectedBool = false;
        SceneManager.LoadScene(0);

    }

    public void MissionSelected()
    {
        MisionSeleccionada = ActiveMission;
        MissionSelectedBool = true;
    }

    public void ActualGunV(int ArmaNum)
    {
        addProduct = Armas[ArmaNum].GetComponent<AddProduct>();
        addProduct.thisProduct.itemCode = ArmaNum;
        

    }

    public void GunSelected()
    {
        ArmaSeleccionada = ActiveGun;
        GunSelectedBool = true;
    }

    void RevisionCompra(int ArmaNum)
    {
        if (addProduct != null)
        {
            if (addProduct.thisProduct.isPurchased == true || PlayerPrefs.GetInt("G"+ArmaNum) == 1)
            {
                GunBuyed[ArmaNum] = true;
                PlayerPrefs.SetInt("G" + ArmaNum, 1);
                
                BuyedBTN[ArmaNum].SetActive(true);
                NotBuyedBTN[ArmaNum].SetActive(false);
                //addProduct.thisProduct.itemCost = 0;

            }
            else if (addProduct.thisProduct.isPurchased == false || PlayerPrefs.GetInt("G" + ArmaNum) == 0)
            {
                GunBuyed[ArmaNum] = false;
                PlayerPrefs.SetInt("G"+ArmaNum,0);
                BuyedBTN[ArmaNum].SetActive(false);
                NotBuyedBTN[ArmaNum].SetActive(true);
            }
            
        }


        


        if (GunBuyed[ArmaNum] == true)
        {
            BuyedBTN[ArmaNum].SetActive(true);
            NotBuyedBTN[ArmaNum].SetActive(false);
        }
        else
        {
            BuyedBTN[ArmaNum].SetActive(false);
            NotBuyedBTN[ArmaNum].SetActive(true);

        }


    }
    void ModifyMoneyV()
    {

        if (PlayerPrefs.GetInt("FirstMoney") == 0)
        {
            SaveData.Money = 21000;
            PlayerPrefs.SetInt("FirstMoney", 1);
        }

    }

   
    void Update()
    {

        RevisionCompra(Armanum_);
        ModifyMoneyV();
        

        Armanum_ = SaveData.WeaponEquiped;

        dineroTotal.text = SaveData.Money.ToString();
        PlayerPrefs.SetInt("Money", SaveData.Money);

        

        ActiveMission = missionsButtonManager.actualSate;
        ActiveGun = gunUIcontroller.actualSate;
        ActualGunV(ActiveGun);



        #region Intercambiador paneles (selector mision y selector armas
        if (MissionSelectedBool == true)
        {
            MissionSelector.SetActive(false);
            GunSelector.SetActive(true);
        }
        #endregion
        
        #region Seccion de Botones de compra
        RevisionCompra(ActiveGun);


        #endregion

        if (MissionSelectedBool && GunSelectedBool )
        {
            if (MisionSeleccionada == 0)
            {
                missionsButtonManager.Mission1_V();

            }
            if (MisionSeleccionada == 1)
            {
                missionsButtonManager.Mission2_V();

            }

        }

    }


   

    
}

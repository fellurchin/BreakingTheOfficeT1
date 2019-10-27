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

    public void GoBackV() //Funcion que regresa al menu
    {
        MissionSelectedBool = false; //Mision seleccionada falsa
        GunSelectedBool = false; //Arma seleccionada falsa
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(0);
    }

    public void MissionSelected() //Funcion para seleccion de mision, y bool de mision seleccionada
    {
        MisionSeleccionada = ActiveMission;
        MissionSelectedBool = true;
    }

    public void ActualGunV(int ArmaNum)
    {
        addProduct = Armas[ArmaNum].GetComponent<AddProduct>();
    }

    public void GunSelected() //Funcion donde se levisa si el arma fue comprada, si es asi asigna el arma y activa el bool de arma seleccionada
    {
        if (addProduct.thisProduct.isPurchased)
        {
            ArmaSeleccionada = ActiveGun;
            SaveData.WeaponEquiped = ActiveGun;
            GunSelectedBool = true;
        }
        
    }
    

    void RevisionCompra(int ArmaNum) //Revisa si los productos han sido efectivamente comprados
    {
        if (addProduct != null)
        {
            if (addProduct.thisProduct.isPurchased == true || PlayerPrefs.GetInt("G" + ArmaNum) == 1)
            {
                PlayerPrefs.SetInt("G" + ArmaNum, 1);
                GunBuyed[ArmaNum] = true;
            }
            if (addProduct.thisProduct.isPurchased == false || PlayerPrefs.GetInt("G" + ArmaNum) == 0)
            {
                PlayerPrefs.SetInt("G" + ArmaNum, 0);
                GunBuyed[ArmaNum] = false;
            }
        }

        if (GunBuyed[ArmaNum] == true)
        {
            BuyedBTN[ArmaNum].SetActive(true);
            NotBuyedBTN[ArmaNum].SetActive(false);
        }
        if (GunBuyed[ArmaNum] == false)
        {
            BuyedBTN[ArmaNum].SetActive(false);
            NotBuyedBTN[ArmaNum].SetActive(true);
        }
    }

    

    void ModifyMoneyV() //Modifica el dinero si el juego es reseteado
    {
        if (PlayerPrefs.GetInt("FirstMoney") == 0)
        {
            SaveData.Money = 30000;
            PlayerPrefs.SetInt("FirstMoney", 1);
        }
    }

   
    void Update()
    {
        RevisionCompra(Armanum_);

        ModifyMoneyV();

        Armanum_ = gunUIcontroller.actualSate;

        dineroTotal.text = "$ " + SaveData.Money.ToString();
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

        #region Comprobador de paso a mision
        if (MissionSelectedBool && GunSelectedBool) //solo si una mision y un arma han sido seleccionadas pasa a los mundos 
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
        #endregion


    }


   

    
}

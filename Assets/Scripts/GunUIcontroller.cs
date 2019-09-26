using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunUIcontroller : MonoBehaviour
{
    AddProduct addProduct;
    public ActiveThings activeThings;

    [SerializeField] TextMeshProUGUI GunNameTEXT;
    [SerializeField] TextMeshProUGUI GunPriceTEXT;


    [Header("Botones Izquierda y derecha")]
    public Button leftButton;
    public Button rightButton;

    [Header("Paneles de cada arma")]
    public GameObject[] GunOBJS;

    [Header("Arma Actual")]
    public int actualSate = 0;

    [Header("Precios De las armas")]
    public int[] GunPrices;

    int g1 = 30000;
    int g2 = 40000;
    int g3 = 50000;
    int g4 = 60000;
    int g5 = 70000;
    int g6 = 80000;

    public TextMeshProUGUI[] PrecioArmas;
    public bool nonActive = false;

    int ArmaNum;


    // Start is called before the first frame update
    void Start()
    {
        actualSate = 0;

        GunPrices = new int[6];
        GunPrices[0] = g1;
        GunPrices[1] = g2;
        GunPrices[2] = g3;
        GunPrices[3] = g4;
        GunPrices[4] = g5;
        GunPrices[5] = g6;

        
        leftButton.onClick.AddListener(Back);
        rightButton.onClick.AddListener(Next);
    }

    void Update()
    {
        ArmaNum = actualSate;

        #region Control estado actual

        
        if (actualSate < 0)
        {
            actualSate = 0;
        }
        if (actualSate >= GunOBJS.Length)
        {
            actualSate = GunOBJS.Length - 1;
        }
        //control Aparicion Botones
        if (actualSate == 0)
        {
            leftButton.interactable = false;
        }
        else leftButton.interactable = true;

        if (actualSate >= GunOBJS.Length - 1)
        {
            rightButton.interactable = false;
        }
        else rightButton.interactable = true;
        //Cierre Aparicion Botones

        GunOBJS[actualSate].SetActive(true);


        if (nonActive == true)
        {
            for (int i = 0; i < GunOBJS.Length; i++)
            {
                GunOBJS[i].SetActive(false);


            }
            nonActive = false;
        }
        #endregion

        #region Texto de las armas

        switch (actualSate)
        {
            case 0:
                GunNameTEXT.text = "Arma1";
                break;
            case 1:
                GunNameTEXT.text = "Arma2";
                break;
            case 2:
                GunNameTEXT.text = "Arma3";
                break;
            case 3:
                GunNameTEXT.text = "Arma4";
                break;
            case 4:
                GunNameTEXT.text = "Arma5";
                break;
            case 5:
                GunNameTEXT.text = "Arma6";
                break;
            case 6:
                GunNameTEXT.text = "Arma7";
                break;

            default:
                break;
        }
        #endregion

        #region Precio de las armas


        addProduct = activeThings.Armas[ArmaNum].GetComponent<AddProduct>();

        PlayerPrefs.SetInt("PrecioA1", g1);
        PlayerPrefs.SetInt("PrecioA2", g2);
        PlayerPrefs.SetInt("PrecioA3", g3);
        PlayerPrefs.SetInt("PrecioA4", g4);
        PlayerPrefs.SetInt("PrecioA5", g5);
        PlayerPrefs.SetInt("PrecioA6", g6);

        

        


        switch (actualSate)
        {
            case 0:
                PrecioArmas[0].text = "$ "+ g1.ToString();
                //PlayerPrefs.SetInt("PrecioA1", g1);
                addProduct.thisProduct.itemCost = PlayerPrefs.GetInt("PrecioA1");
                break;
            case 1:
                PrecioArmas[1].text = "$ " + g2.ToString();
                //PlayerPrefs.SetInt("PrecioA2", g2);
                addProduct.thisProduct.itemCost = PlayerPrefs.GetInt("PrecioA2");
                
                break;
            case 2:
                PrecioArmas[2].text = "$ " + g3.ToString();
                //PlayerPrefs.SetInt("PrecioA3", g3);
                addProduct.thisProduct.itemCost = PlayerPrefs.GetInt("PrecioA3");

                break;
            case 3:
                PrecioArmas[3].text = "$ " + g4.ToString();
                //PlayerPrefs.SetInt("PrecioA4", g4);
                addProduct.thisProduct.itemCost = PlayerPrefs.GetInt("PrecioA4");

                break;
            case 4:
                PrecioArmas[4].text = "$ " + g5.ToString();
                //PlayerPrefs.SetInt("PrecioA5", g5);
                addProduct.thisProduct.itemCost = PlayerPrefs.GetInt("PrecioA5");

                break;
            case 5:
                PrecioArmas[5].text = "$ " + g6.ToString();
                //PlayerPrefs.SetInt("PrecioA6", g6);
                addProduct.thisProduct.itemCost = PlayerPrefs.GetInt("PrecioA6");

                break;

            default:
                break;
        }
        #endregion
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
}

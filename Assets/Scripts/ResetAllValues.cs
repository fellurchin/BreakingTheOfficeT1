using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAllValues : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("Juego_Iniciado") == null || PlayerPrefs.GetInt("Juego_Iniciado") == 0)
        {
            ResetALL();
            PlayerPrefs.SetInt("Juego_Iniciado", 1);
            
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetALL();
        }
        
    }

    public void ResetALL() //Funcion para acceder a los Guardados y restablecerlos
    {
        PlayerPrefs.SetInt("G0", 0);
        PlayerPrefs.SetInt("G1", 0);
        PlayerPrefs.SetInt("G2", 0);
        PlayerPrefs.SetInt("G3", 0);
        PlayerPrefs.SetInt("G4", 0);
        PlayerPrefs.SetInt("G5", 0);

        PlayerPrefs.SetInt("Objs_1", 0);
        PlayerPrefs.SetInt("Objs_2", 0);

        PlayerPrefs.SetInt("FirstMoney", 0);
        PlayerPrefs.SetInt("Money", 30000);

        SaveData.Money = PlayerPrefs.GetInt("Money");

    }
}

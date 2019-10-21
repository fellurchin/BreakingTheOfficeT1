using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject[] GunsArray;
    private WeaponCol weaponCol;

    public int activeGun;

    public int[] HurtArray = new int[6];


    void Update()
    {
        weaponCol = GameObject.FindGameObjectWithTag("Point").GetComponent<WeaponCol>();
        activeGun = SaveData.WeaponEquiped;

        HurtArray[0] = 30;
        HurtArray[1] = 30;
        HurtArray[2] = 30;
        HurtArray[3] = 80;
        HurtArray[4] = 80;
        HurtArray[5] = 80;

        #region Switch valor Daño
        switch (activeGun)
        {
            case 0:
                weaponCol.HealthToRemove = HurtArray[0];
                break;
            case 1:
                weaponCol.HealthToRemove = HurtArray[1];
                break;
            case 2:
                weaponCol.HealthToRemove = HurtArray[2];
                break;
            case 3:
                weaponCol.HealthToRemove = HurtArray[3];
                break;
            case 4:
                weaponCol.HealthToRemove = HurtArray[4];
                break;
            case 5:
                weaponCol.HealthToRemove = HurtArray[5];
                break;


            default:
                break;
        }

        #endregion

        if (true)
        {
            GunSelected(activeGun); //No tocar, permite la seleccion del arma
        }
    }
    void GunSelected(int activeGun)
    {
        foreach (GameObject gameObject in GunsArray)
        {
            gameObject.SetActive(false);
        }
        GunsArray[activeGun].SetActive(true);

    }
}

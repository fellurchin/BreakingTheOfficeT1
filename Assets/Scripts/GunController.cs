using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject[] GunsArray;
    private WeaponCol weaponCol;
   

    public int activeGun;

    public bool canChangeGun = false;

    public bool G1Active = false;
    public bool G2Active = false;
    public bool G3Active = false;
    public bool G4Active = false;
    public bool G5Active = false;
    public bool G6Active = false;

    public int[] HurtArray = new int[6];


    // Start is called before the first frame update
    void Start()
    {
        HurtArray[0] = 30;
        HurtArray[1] = 40;
        HurtArray[2] = 50;
        HurtArray[3] = 60;
        HurtArray[4] = 70;
        HurtArray[5] = 80;



    }

    // Update is called once per frame
    void Update()
    {
        
        weaponCol = GameObject.FindGameObjectWithTag("Point").GetComponent<WeaponCol>();
        activeGun = SaveData.WeaponEquiped;

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
            GunSelected(activeGun);
        }


        //if (activeGun < 0)
        //{
        //    activeGun = 0;
        //}
        //if (activeGun >= GunsArray.Length -1)
        //{
        //    activeGun = GunsArray.Length - 1;
        //}




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

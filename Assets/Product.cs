using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Product
{
    public int itemCode;
    public int itemCost;
    public bool isPurchased;


    public void Initialize()
    {
        if (PlayerPrefs.GetInt(("G") + itemCode) == 0)
        {
            isPurchased = false;
        }
        else
        {
            isPurchased = true;
        }
    }

    //luego se puede poner que se actualizen los datos desde playerprefs
    //por ahora las variables estan publicas para que en el inspector se pueda editar
    //se tiene que hacer que cuando el juego se inicie el isPurchased cambie de verdadero o falso...
    //segun la informacion guardada diga que se compro el item con anterioridad
    //Se sugiere usar la siguiente funcion para eso, pues ya se usa en otro script asi pero puede
    //ser algo distinto mientras permita saber si ya fue comprado
    //if(SaveData.UnlockedWeapon[itemCode] != 0) { isPurchased = true; )
}

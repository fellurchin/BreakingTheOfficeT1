using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Shopkeeper
{
   //evento de producto comprado

    public static bool BuyProduct(Product item)
    {
        if (SaveData.Money >= item.itemCost)
        {
            //SaveData.UnlockedWeapon[itemCode] = 1;   //cuando el jugador compre el arma se desbloquea en el save data(playerprefs)
            SaveData.Money -= item.itemCost;
            return true;
        }
        else
        {
            return false;
        }
    }
}

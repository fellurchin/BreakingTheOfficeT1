using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddProduct : MonoBehaviour
{
    
    public Product thisProduct;

    public void PurchaseOrEquipProduct() //cuando se quiera comprar el producto llamar esta funcion
    {
        
        if (thisProduct.isPurchased == false)
        {
            Debug.Log("Intento de compra" + thisProduct.itemCode);
            if (Shopkeeper.BuyProduct(thisProduct))
            {
                thisProduct.isPurchased = true;
                PlayerPrefs.SetInt("G" + thisProduct.itemCode, 1);
            }
            else
            {
                //puede salir un mensaje que diga que no hay suficiente dinero
            }
        }
        else //si el producto ya estaba comprado se equipa
        {
            SaveData.WeaponEquiped = thisProduct.itemCode;
        }
    }
    private void Awake()
    {
        thisProduct.Initialize();
    }
}

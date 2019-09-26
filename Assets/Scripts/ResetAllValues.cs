using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAllValues : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetALL();
        }
    }

    public void ResetALL()
    {
        

        
        PlayerPrefs.SetInt("G0", 0);
        PlayerPrefs.SetInt("G1", 0);
        PlayerPrefs.SetInt("G2", 0);
        PlayerPrefs.SetInt("G3", 0);
        PlayerPrefs.SetInt("G4", 0);
        PlayerPrefs.SetInt("G5", 0);

        PlayerPrefs.SetInt("MaxScore", 0);

        PlayerPrefs.SetInt("Objs_1", 0);
        PlayerPrefs.SetInt("Objs_2", 0);

        PlayerPrefs.SetInt("FirstMoney", 0);
        PlayerPrefs.SetInt("Money", 30000);
        SaveData.Money = 30000;

    }
}

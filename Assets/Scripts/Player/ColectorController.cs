using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectorController : MonoBehaviour
{
    public ShowDataHUD ShowDataHUD;

    void Start() => ShowDataHUD = GameObject.Find("ShowDataHud").GetComponent<ShowDataHUD>();

    private void OnTriggerEnter(Collider Col)
    {
        if (Col.tag == "Gold")
        {
            ShowDataHUD.AddToScore(2000);
            Destroy(Col.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectorController : MonoBehaviour
{
    public ShowDataHUD ShowDataHUD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.tag == "Gold")
        {
            ShowDataHUD.AddToScore(2000);
            Destroy(Col.gameObject);
        }
    }
}

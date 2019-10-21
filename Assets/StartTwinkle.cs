using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartTwinkle : MonoBehaviour
{
    
    TextMeshProUGUI StartGameTXT;
    static public Color blackColor = new Vector4(0,0,0,1);
    static public Color whiteColor = new Vector4(1, 1, 1, 1);

    static Color lerpedColor = Color.white;
    // Start is called before the first frame update
   

    private void Start()
    {
         StartGameTXT = GameObject.Find("StartText (TMP)").GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        lerpedColor = Color.Lerp(Color.black, Color.white, Mathf.PingPong(Time.time, 1.5f));
        StartGameTXT.color = lerpedColor; 
        
    }
}

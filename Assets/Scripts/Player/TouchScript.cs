using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour
{
    public Transform jButton;
    private Transform initialJButtonPos;

    private void Awake() => initialJButtonPos.position = jButton.position;


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            jButton.position = touch.position;

        }
        else jButton.position = initialJButtonPos.position;
    }



}

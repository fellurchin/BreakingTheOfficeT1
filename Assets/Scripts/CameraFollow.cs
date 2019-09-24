using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraDistOffset = 10;
    private Camera mainCamera;
    public GameObject player;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        //player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 playerInfo = player.transform.transform.position;
        mainCamera.transform.position = new Vector3(playerInfo.x ,mainCamera.transform.position.y ,playerInfo.z - cameraDistOffset);
    }
}

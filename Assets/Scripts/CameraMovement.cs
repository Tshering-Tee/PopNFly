using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMovement : MonoBehaviour
{
    public Transform player;
    public Transform mainCamera;
    public Vector3 offset = new Vector3(0, 0, -5);
    void LateUpdate()
    {  
        mainCamera.position = player.position + offset;
    }
}
                   
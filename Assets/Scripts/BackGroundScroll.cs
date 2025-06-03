using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    public Material bg;    
              
    public Transform player;            
    private Vector3 previousPosition;  
    public float scrollSpeed = 0.1f;    
    
    void Start()
    {
        previousPosition = player.position;  
    }

    void Update()
    {
        
        float deltaX = player.position.x - previousPosition.x;

        bg.mainTextureOffset += new Vector2(deltaX * scrollSpeed, 0);
        
        previousPosition = player.position;
    }
}

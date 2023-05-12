using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @Gerenciador de tarefas da camera 
 */

public class CameraManager : MonoBehaviour
{
    public float LeftEdge;
    public float RightEdge;

    public Transform PlayerPosition;

    private void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        LeftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        RightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    }

    private void Update()
    {
        
    }

   
}

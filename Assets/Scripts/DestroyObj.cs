using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{    
    [SerializeField]
    private float DelTime;    

    void Start()
    {
        Invoke("Destroy", DelTime);       
    }

    
    void Destroy()
    {
        Destroy(gameObject);          
    }
}

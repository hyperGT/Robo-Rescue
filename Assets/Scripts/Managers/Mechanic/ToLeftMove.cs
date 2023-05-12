using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 * @Movimenta��o para a esquerda
 * Funcional para todos os inimigos e colet�veis
 * 
 */

public class ToLeftMove : MonoBehaviour
{
    [Header("Object Left Move Velocity")]
    [SerializeField] private float ToLeftSpeed;

    [Header("Camera Components")]
    // Refer�ncia � c�mera principal
    private Camera MainCamera;

    // Armazena o limite da c�mera na borda esquerda
    private float LeftEdge;

    private void Start()
    {
        MainCamera = Camera.main;
        LeftEdge = MainCamera.GetComponent<CameraManager>().LeftEdge;
    }

    void Update()
    {
        //Movimenta o [Objeto]
        MoveLeft();
    }

    void MoveLeft()
    {
        //movimenta o [Objeto] para a esquerda 
        transform.Translate(Vector2.left * ToLeftSpeed * Time.deltaTime);

        // Verifica se o [Objeto] est� al�m do limite da c�mera na borda esquerda
        if (transform.position.x < LeftEdge)
        {
            //destroi o [Objeto]
            Destroy(gameObject);
        }
    }

    
}

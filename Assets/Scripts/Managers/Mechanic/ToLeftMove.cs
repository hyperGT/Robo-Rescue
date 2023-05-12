using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 * @Movimentação para a esquerda
 * Funcional para todos os inimigos e coletáveis
 * 
 */

public class ToLeftMove : MonoBehaviour
{
    [Header("Object Left Move Velocity")]
    [SerializeField] private float ToLeftSpeed;

    [Header("Camera Components")]
    // Referência à câmera principal
    private Camera MainCamera;

    // Armazena o limite da câmera na borda esquerda
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

        // Verifica se o [Objeto] está além do limite da câmera na borda esquerda
        if (transform.position.x < LeftEdge)
        {
            //destroi o [Objeto]
            Destroy(gameObject);
        }
    }

    
}

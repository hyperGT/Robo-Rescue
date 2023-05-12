using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Funcional para disparos de projéteis e outras mecânicas que necessitam mover alguma
 * coisa para direita pela cena(sem uso de física)
 */

public class ToRightMove : MonoBehaviour
{
    // Referência à câmera principal
    private Camera MainCamera;

    // Armazena o limite da câmera na borda direita
    private float RightEdge;

    [Header("Bullet or Others Obj Speed")]
    [SerializeField] 
    private float ToRightSpeed;

    private void Start()
    {
        // Obtém a referência à câmera principal
        MainCamera = Camera.main;

        // Calcula a posição do limite da câmera
        RightEdge = MainCamera.GetComponent<CameraManager>().RightEdge;
    }

    

    void Update()
    {
        MoveRight();
    }

    void MoveRight()
    {
        
        transform.Translate(Vector2.right * ToRightSpeed * Time.deltaTime);
        // Verifica se o projétil está além do limite da câmera
        if (transform.position.x > RightEdge)
        {
            //destroi o projétil
            Destroy(gameObject);
        }
    }
}

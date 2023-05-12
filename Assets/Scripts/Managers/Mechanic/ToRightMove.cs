using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Funcional para disparos de proj�teis e outras mec�nicas que necessitam mover alguma
 * coisa para direita pela cena(sem uso de f�sica)
 */

public class ToRightMove : MonoBehaviour
{
    // Refer�ncia � c�mera principal
    private Camera MainCamera;

    // Armazena o limite da c�mera na borda direita
    private float RightEdge;

    [Header("Bullet or Others Obj Speed")]
    [SerializeField] 
    private float ToRightSpeed;

    private void Start()
    {
        // Obt�m a refer�ncia � c�mera principal
        MainCamera = Camera.main;

        // Calcula a posi��o do limite da c�mera
        RightEdge = MainCamera.GetComponent<CameraManager>().RightEdge;
    }

    

    void Update()
    {
        MoveRight();
    }

    void MoveRight()
    {
        
        transform.Translate(Vector2.right * ToRightSpeed * Time.deltaTime);
        // Verifica se o proj�til est� al�m do limite da c�mera
        if (transform.position.x > RightEdge)
        {
            //destroi o proj�til
            Destroy(gameObject);
        }
    }
}

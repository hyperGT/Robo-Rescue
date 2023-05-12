using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // velocidade do obj no eixo X e Y(como estamos falando de uma aeronave ela deve ter velocidades diferentes)
    [Header("Velocidade do Player")]
    [SerializeField] private float VelY, VelX;

    private Rigidbody2D PlayerRB;


    private void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        LeituraTeclasEixoX();
        LeituraTeclasEixoY();
        ScreenLimiter();        
    }

    //impede que o jogador saia dos limites da tela(camera)
    private void ScreenLimiter()
    {
        // Verificando o posicionamento do player na tela 
        var distanceZ = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceZ)).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceZ)).x;

        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceZ)).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distanceZ)).y;

        //esse trecho é responsável por limitar de fato a movimentação do player quando chegar a uma certa distância da borda da câmera
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder + 1, rightBorder - 1),
            Mathf.Clamp(transform.position.y, topBorder + 0.8f, bottomBorder - 2.6f),
            transform.position.z
            );
    }



    //Leitura Eixo Y
    void LeituraTeclasEixoY()
    {
        if(Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)))
        {
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, VelY); 
        }
        else if(Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
        {
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, -VelY);
        }
        else
        {
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, 0);
        }
    }

    //Leitura Eixo X
    void LeituraTeclasEixoX()
    {
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            PlayerRB.velocity = new Vector2(-VelX, PlayerRB.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            PlayerRB.velocity = new Vector2(VelX, PlayerRB.velocity.y);
        }
        else
        {
            PlayerRB.velocity = new Vector2(0, PlayerRB.velocity.y);
        }
    }



}

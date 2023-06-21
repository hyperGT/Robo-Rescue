using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // velocidade do obj no eixo X e Y
    [Header("Velocidade do Player Eixo Y")]
    [SerializeField] private float VelocitY;

    [Header("Velocidade do Player Eixo X")]
    [SerializeField] private float VelocitX;

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

        //esse trecho � respons�vel por limitar de fato a movimenta��o do player quando chegar a uma certa dist�ncia da borda da c�mera
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
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, VelocitY); 
        }
        else if(Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
        {
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, -VelocitY);
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
            PlayerRB.velocity = new Vector2(-VelocitX, PlayerRB.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            PlayerRB.velocity = new Vector2(VelocitX, PlayerRB.velocity.y);
        }
        else
        {
            PlayerRB.velocity = new Vector2(0, PlayerRB.velocity.y);
        }
    }



}

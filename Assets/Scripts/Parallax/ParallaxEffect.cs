using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    //código do efeito parallax | deve ser adicionado aos objetos que precisam desse efeito

    [SerializeField] private float velocity; //a velocidade do efeito
    [SerializeField] private Renderer Quad; //Capturar esse componente de Renderer

    private Vector2 Offset;

    private void Start() => Quad = GetComponent<Renderer>();

    private void Update()
    {
        Offset = new Vector2(velocity * Time.deltaTime, 0);

        Quad.material.mainTextureOffset += Offset;
    }


}

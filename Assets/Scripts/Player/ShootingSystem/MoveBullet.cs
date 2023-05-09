using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    // Velocidade do projétil
    [Header("Bullet Speed")]
    [SerializeField] private float Speed = 14f;
    
    [Header("Bullet Damage")]
    [SerializeField] private int BulletDamage;
    
    //para poder acessar o valor do dano do projétil em qualquer outro código
    public static int CurrentBulletDamage; 

    // Referência à câmera principal
    private Camera MainCamera;

    // Armazena o limite da câmera na borda direita
    private float RightEdge;

    private void Start()
    {
        // Obtém a referência à câmera principal
        MainCamera = Camera.main;

        // Calcula a posição do limite da câmera
        RightEdge = MainCamera.GetComponent<CameraManager>().RightEdge;
    }

    void Update()
    {
        CurrentBulletDamage = BulletDamage;
        DestroyBullet();
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }


    void DestroyBullet()
    {
        // Verifica se o projétil está além do limite da câmera
        if (transform.position.x > RightEdge)
        {
            //destroi o projétil
            Destroy(gameObject);
        }
    }

}

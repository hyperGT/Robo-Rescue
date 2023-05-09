using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    // Velocidade do proj�til
    [Header("Bullet Speed")]
    [SerializeField] private float Speed = 14f;
    
    [Header("Bullet Damage")]
    [SerializeField] private int BulletDamage;
    
    //para poder acessar o valor do dano do proj�til em qualquer outro c�digo
    public static int CurrentBulletDamage; 

    // Refer�ncia � c�mera principal
    private Camera MainCamera;

    // Armazena o limite da c�mera na borda direita
    private float RightEdge;

    private void Start()
    {
        // Obt�m a refer�ncia � c�mera principal
        MainCamera = Camera.main;

        // Calcula a posi��o do limite da c�mera
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
        // Verifica se o proj�til est� al�m do limite da c�mera
        if (transform.position.x > RightEdge)
        {
            //destroi o proj�til
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSpawnEnemy : MonoBehaviour
{
    private Rigidbody2D CriarRB;

    [SerializeField] private float VelY;

    [SerializeField] private GameObject[] Enemies;

    private bool canSpawn;


    private void Start()
    {
        CriarRB = GetComponent<Rigidbody2D>();
        Invoke("StartMove", 2f);
    }


    private void StartMove()
    {
        CriarRB.velocity = new Vector2(CriarRB.velocity.x, VelY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cima"))
        {
            CriarRB.velocity = new Vector2(CriarRB.velocity.x, -VelY);
        }
        if (collision.gameObject.CompareTag("baixo"))
        {
            CriarRB.velocity = new Vector2(CriarRB.velocity.x, VelY);
        }
    }


}

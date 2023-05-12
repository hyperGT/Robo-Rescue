using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSpawnEnemy : MonoBehaviour
{
    private Rigidbody2D CriarRB;

    [SerializeField] private float VelY;

    [Header("Spawn System")]
    [SerializeField] private float SpanwRate = 1f;

    private bool CanSpawn = true; 

    [SerializeField] private GameObject[] Enemies;

    [SerializeField] private Transform SpawnPosition;



    private void Start()
    {
        CriarRB = GetComponent<Rigidbody2D>();
        Invoke("StartMove", 2f);
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(SpanwRate);

        while (CanSpawn) 
        { 
            yield return wait;

            int EnemyRand = Random.Range(0, Enemies.Length);
            GameObject EnemyToSpawn = Enemies[EnemyRand];

            Instantiate(EnemyToSpawn, SpawnPosition.position, Quaternion.identity);
        }
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

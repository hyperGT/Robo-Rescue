using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [Header("Enemy Total Life")]
    [SerializeField] private int EnemyHealth;

    private void Update()
    {
        if (EnemyHealth <= 0) 
        { 
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerShot"))
        {
            Destroy(collision.gameObject);
            EnemyHealth -= MoveBullet.CurrentBulletDamage;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("perdeu vida");
        }
    }
}

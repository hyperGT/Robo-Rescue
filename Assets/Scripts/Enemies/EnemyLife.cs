using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [Header("Enemy Total Life")]
    [SerializeField] private int EnemyHealth;

    [Header("Points")]
    [SerializeField] private int Points;

    private int BulletDmg;

    private void Update()
    {
        BulletDmg = BulletDamage.CurrentBulletDamage;
        if (EnemyHealth <= 0) 
        { 
            Destroy(gameObject);
            UIController.instance.CurrentScorePlayer += Points;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerShot"))
        {
            Destroy(collision.gameObject);
            EnemyHealth -= BulletDmg;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("perdeu vida");
            UIController.instance.LifeBar -= 1;
        }
    }
}

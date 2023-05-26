using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [Header("Enemy Total Life")]
    [SerializeField] private int EnemyHealth;

    [Header("Points")]
    [SerializeField] private int Points;

    [Header("Components")]
    [SerializeField] private GameObject Explosion;
    [SerializeField] private GameObject PointsObj;

    [Header("Points Spawn Time")]
    [SerializeField] private float InvokeTime = 0.5f;

    private int BulletDmg;

    private void Update()
    {
        BulletDmg = BulletDamage.CurrentBulletDamage;
        if (EnemyHealth <= 0) 
        {
            Invoke("PointsObjSpawn", InvokeTime);
            Instantiate(Explosion, transform.position, Quaternion.identity);            
            Destroy(gameObject);

            UIController.instance.CurrentScorePlayer += Points;
        } 
    }

    private void PointsObjSpawn()
    {
        Instantiate(PointsObj, transform.position, Quaternion.identity);
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

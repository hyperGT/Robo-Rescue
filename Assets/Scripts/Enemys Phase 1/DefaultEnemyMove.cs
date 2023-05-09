using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 * @Movimento do Inimigo/Enemy Movement
 */

public class DefaultEnemyMove : MonoBehaviour
{
    [Header("Enemy Move velocity")]
    [SerializeField] private float MoveSpeed;   

    private float LeftEdge;

    private void Start()
    {
        LeftEdge = Camera.main.GetComponent<CameraManager>().LeftEdge;
    }

    void Update()
    {
        transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);

        if(transform.position.x < LeftEdge)
        {
            Destroy(gameObject);
        }
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{        
    [Header("Bullet Damage")]
    [SerializeField] private int TotalBulletDamage;
    
    //para poder acessar exclusivamente o valor do dano do proj�til em qualquer outro c�digo
    public static int CurrentBulletDamage;     
    
    
    void Update()
    {
        CurrentBulletDamage = TotalBulletDamage;                
    }


    

}

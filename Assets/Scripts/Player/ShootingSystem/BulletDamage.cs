using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{        
    [Header("Bullet Damage")]
    [SerializeField] private int TotalBulletDamage;
    
    //para poder acessar exclusivamente o valor do dano do projétil em qualquer outro código
    public static int CurrentBulletDamage;     
    
    
    void Update()
    {
        CurrentBulletDamage = TotalBulletDamage;                
    }


    

}

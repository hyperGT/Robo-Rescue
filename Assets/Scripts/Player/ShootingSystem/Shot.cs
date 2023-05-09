using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [Header("Bullet Types")]
    [SerializeField] private GameObject[] BulletsPreFab; //vai guardar todos os tipos de projéteis que o jogador puder usar

    [SerializeField] private float TimerShot; //timer do tiro

    [Header("Shot Position")]    
    [SerializeField] private Transform ShotPosition;

    private bool canShot = false;

    private void Update()
    {
        LeituraTiro();
    }

    private void LeituraTiro()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!canShot)
            {
                canShot = true;

                Instantiate(BulletsPreFab[0], ShotPosition.position, Quaternion.identity);

                StartCoroutine("timerTiro");
            }
        }
    }

    private IEnumerator timerTiro()
    {
        if (canShot)
        {
            yield return new WaitForSeconds(TimerShot);
            canShot = false;
        }
    }
}

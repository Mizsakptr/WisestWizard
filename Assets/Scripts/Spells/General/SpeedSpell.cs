using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSpell : MonoBehaviour
{
    public GameObject player;
    private PlayerStats playerStats;
    //public ManaBar manaBar; ez úgy néz ki, nem kell
    public float speedModifyer = 1f;
    public float targetTime = 0f;
    public bool isSpeedSpell = false;

    private void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
    }

    void Update()
    {        

        if (isSpeedSpell)
        {
            playerStats.currentMana -= 5;
            isSpeedSpell = false;
        }

        if (targetTime > 0f)
        {
            targetTime -= Time.deltaTime;
            speedModifyer = 10f;
        }

        if (targetTime <= 0f)
        {
            speedModifyer = 1f;
        }   

    }

}

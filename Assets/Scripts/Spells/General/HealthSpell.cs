using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpell : MonoBehaviour
{
    public GameObject player;
    private PlayerStats playerStats;
    public bool isHealthSpell = false;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isHealthSpell)
        {
            playerStats.currentHealth += 5;
            playerStats.currentMana -= 5;
            isHealthSpell = false;
        }           
        
        
    }
}

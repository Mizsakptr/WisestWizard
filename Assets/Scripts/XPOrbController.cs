using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class XPOrbController : MonoBehaviour
{

    //public GameObject player;
    private PlayerStats playerStats;
    public bool touching = false;

    private void Start()
    {
        //playerStats = player.GetComponent<PlayerStats>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }


    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            playerStats.currentXP += 5;
            Destroy(this.gameObject);
            touching = true;
            //Debug.Log(collision.gameObject.name);
        }              

    }
}

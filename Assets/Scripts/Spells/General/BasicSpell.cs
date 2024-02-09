using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpell : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public float launchVelocity = 10f;
    public bool isBasicSpell = false;
    public ManaBar manaBar;
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
    }

    void Update()
    {
        Vector3 projectilePosition = player.transform.position + player.transform.forward * 2;
        if (Input.GetMouseButtonDown(0) && isBasicSpell == true)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                Vector3 direction = (hit.point - projectilePosition);
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);

                GameObject ball = Instantiate(projectile, projectilePosition, transform.rotation);
                ball.GetComponent<Rigidbody>().velocity = direction.normalized * launchVelocity;   
                playerStats.currentMana -= 5;
                isBasicSpell = false;

            }
            
        }

    }
}

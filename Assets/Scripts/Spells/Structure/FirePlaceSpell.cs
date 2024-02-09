using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlaceSpell : MonoBehaviour
{
    public GameObject player;
    public GameObject fireplace;
    GameObject logs;
    public bool isFirePlaceSpell = false;
    bool isPositioning = false;

    void Start()
    {
        
    }

    void Update()
    {

        
        if (isFirePlaceSpell && !isPositioning)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                logs = Instantiate(fireplace, hit.point, transform.rotation);
                
            }

            isPositioning=true;            

        }

        if (isFirePlaceSpell && isPositioning)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                logs.transform.position = hit.point;

            }            

        }






        if (Input.GetMouseButtonDown(0) && isFirePlaceSpell)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                logs = Instantiate(fireplace, hit.point, transform.rotation);
                isFirePlaceSpell = false;

            }

        }


    }
}

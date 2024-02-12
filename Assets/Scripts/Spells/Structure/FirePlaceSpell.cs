using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlaceSpell : MonoBehaviour
{
    public GameObject player;
    public GameObject fireplace;
    public GameObject fpPositioning;
    GameObject logs;
    GameObject positioninglogs;
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
                positioninglogs = Instantiate(fpPositioning, hit.point, Quaternion.identity);
                
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
                positioninglogs.transform.position = hit.point;

            }
            
        }


        if (Input.GetMouseButtonDown(0) && isFirePlaceSpell)
        {
            Destroy(positioninglogs);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                Instantiate(fireplace, hit.point, Quaternion.identity);
                isPositioning = false;
                isFirePlaceSpell = false;

            }

        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckPath : MonoBehaviour
{
    public Transform target;
    public bool isWalkable;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshPath path = new NavMeshPath();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        
        if (agent != null && NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path))
        {
            // Ellenõrizd az útvonal érvényességét
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                //Debug.Log("Az útvonal érvényes!");
                isWalkable = true;
                        
            }
            else
            {
               //Debug.Log("Az útvonal érvénytelen!");
                isWalkable= false;
            }
        }
        else
        {
            //Debug.Log("Nem sikerült kiszámítani az útvonalat!");
        }
        

        
    }
}

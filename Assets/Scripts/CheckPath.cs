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
            // Ellen�rizd az �tvonal �rv�nyess�g�t
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                //Debug.Log("Az �tvonal �rv�nyes!");
                isWalkable = true;
                        
            }
            else
            {
               //Debug.Log("Az �tvonal �rv�nytelen!");
                isWalkable= false;
            }
        }
        else
        {
            //Debug.Log("Nem siker�lt kisz�m�tani az �tvonalat!");
        }
        

        
    }
}

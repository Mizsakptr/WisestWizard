using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    //public GameObject[] walls;
    public GameObject[] doors;
    public bool[] testStatus;
    void Start()
    {
        UpdateRoom();                                //UpdateRoom(testStatus);
    }

    void UpdateRoom()                                //void UpdateRoom(bool[] status)
    {
        for(int i = 0; i < 4; i++)                   //for(int i = 0; i < status.Length; i++)  
        {
            doors[i].SetActive(rnd());  
            //doors[i].SetActive(!status[i]);
           // Debug.Log(rnd());
        }

    }



    bool rnd()
    {
        if (Random.value > 0.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

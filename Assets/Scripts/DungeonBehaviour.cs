using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DungeonBehaviour : MonoBehaviour
{
    public int dungeonSize;

    public int szel;
    public int hossz;
    
    public GameObject roomprefab;
    GameObject[] doors = new GameObject[4];
    //GameObject[,] dungeon = new GameObject[3,5];

    void Start()
    {
              
        GameObject[,] dungeon = new GameObject[szel, hossz];
        for (int i = 0; i < hossz; i++)
        {
            for (int j = 0; j < szel; j++)
            {

                GameObject room = Instantiate(roomprefab, new Vector3(i * 8f, 0f, j * 8f), transform.rotation);
                room.transform.SetParent(transform);
                for(int k = 0; k < 4; k++)
                {
                    room.transform.GetChild(1).GetChild(k).gameObject.SetActive(rnd());
                }
                
                dungeon[j, i] = room;

            }
        }

        /*
        dungeon[3, 4].transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        dungeon[3, 4].transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        dungeon[3, 4].transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        dungeon[3, 4].transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
        */

        if(!dungeon[3, 4].transform.GetChild(1).GetChild(1).gameObject.activeSelf)
        {
            dungeon[2, 4].transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
        }


        for (int i = 0; i < hossz; i++)
        {
            for (int j = 0; j < szel-1; j++)
            {
                if (!dungeon[j, i].transform.GetChild(1).GetChild(3).gameObject.activeSelf)
                {
                    dungeon[j + 1, i].transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
                }
            }
        }

        for (int i = 0; i < hossz; i++)
        {
            for (int j = 1; j < szel; j++)
            {
                if (!dungeon[j, i].transform.GetChild(1).GetChild(1).gameObject.activeSelf)
                {
                    dungeon[j - 1, i].transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
                }
            }
        }

        for (int i = 0; i < hossz - 1; i++)
        {
            for (int j = 0; j < szel; j++)
            {
                if (!dungeon[j, i].transform.GetChild(1).GetChild(0).gameObject.activeSelf)
                {
                    dungeon[j, i+1].transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
                }
            }
        }

        for (int i = 1; i < hossz; i++)
        {
            for (int j = 0; j < szel; j++)
            {
                if (!dungeon[j, i].transform.GetChild(1).GetChild(2).gameObject.activeSelf)
                {
                    dungeon[j, i-1].transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                }
            }
        }



    }
       


    bool rnd()
    {
        if (UnityEngine.Random.value > 0.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



}

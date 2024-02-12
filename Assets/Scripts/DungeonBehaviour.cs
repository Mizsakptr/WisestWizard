using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DungeonBehaviour : MonoBehaviour
{
    public int dungeonSize;

    float timer = 0f;
    float waitTime = 3f;



    public int szel;
    public int hossz;

    public GameObject player;
    public GameObject startobject;
    public GameObject endobject;
    
    public GameObject roomprefab;
    GameObject[] doors = new GameObject[4];
    private CheckPath isPathWalkable;

    public GameObject[,] dungeon;

    void Start()
    {
        isPathWalkable = startobject.GetComponent<CheckPath>();
        DungeonBrain();

        player.transform.position = new Vector3(0f, 0.2f, 0f);
        startobject.transform.position = new Vector3(0f, 0f, 0f);
        endobject.transform.position = new Vector3(32f, 1f, 40f);


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

    private void Update()
    {
        Debug.Log(isPathWalkable.isWalkable);

        if (!isPathWalkable.isWalkable)
        {
            
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {

                        Debug.Log("asd");
                for (int i = 0; i < transform.childCount; i++)
                {
                    Destroy(transform.GetChild(i).gameObject);
                    Debug.Log(transform.GetChild(i).name);
                }            
                                
                DungeonBrain();
                timer = 0f; 
            }
        }

    }

    void DungeonBrain()
    {
        


        GameObject[,] dungeon = new GameObject[szel, hossz];
        for (int i = 0; i < hossz; i++)
        {
            for (int j = 0; j < szel; j++)
            {

                GameObject room = Instantiate(roomprefab, new Vector3(i * 8f, 0f, j * 8f), transform.rotation);
                room.transform.SetParent(transform);
                for (int k = 0; k < 4; k++)
                {
                    room.transform.GetChild(1).GetChild(k).gameObject.SetActive(rnd());
                }

                dungeon[j, i] = room;

            }
        }


        // Ter�let Bez�r�sa
        for (int i = 0; i < hossz; i++)
        {
            dungeon[0, i].transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            dungeon[szel - 1, i].transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
        }

        for (int j = 0; j < szel; j++)
        {
            dungeon[j, 0].transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
            dungeon[j, hossz - 1].transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        }

        //Ajt�nyit� �s z�r� logika
        for (int i = 0; i < hossz; i++)
        {
            for (int j = 0; j < szel - 1; j++)
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
                    dungeon[j, i + 1].transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
                }
            }
        }

        for (int i = 1; i < hossz; i++)
        {
            for (int j = 0; j < szel; j++)
            {
                if (!dungeon[j, i].transform.GetChild(1).GetChild(2).gameObject.activeSelf)
                {
                    dungeon[j, i - 1].transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }



}

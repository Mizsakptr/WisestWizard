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
    float waitTime = 0.1f;



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

        player.transform.position = new Vector3(12f * MathF.Floor(hossz / 2), 0.5f, 12f * MathF.Floor(szel / 2));
        startobject.transform.position = new Vector3(12f * MathF.Floor(hossz/2), 0f, 12f * MathF.Floor(szel/2));
        


    }    


    bool rnd()
    {
        if (UnityEngine.Random.value > 0.2f) //0.4 jó lesz
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
        //Debug.Log(isPathWalkable.isWalkable);

        if (!isPathWalkable.isWalkable)
        {
            
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                  
                for (int i = 0; i < transform.childCount; i++)
                {
                    Destroy(transform.GetChild(i).gameObject);
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

                GameObject room = Instantiate(roomprefab, new Vector3(i * 12f, 0f, j * 12f), transform.rotation);
                room.transform.SetParent(transform);
                for (int k = 0; k < 4; k++)
                {
                    room.transform.GetChild(1).GetChild(k).gameObject.SetActive(rnd());
                }

                dungeon[j, i] = room;

            }
        }

        endobject.transform.position = new Vector3(12f * (hossz-1), 1f, 12f * (szel-1));


        // Terület Bezárása
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

        //Ajtónyitó és záró logika
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

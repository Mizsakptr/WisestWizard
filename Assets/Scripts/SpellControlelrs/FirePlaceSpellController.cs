using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlaceSpellController : MonoBehaviour
{
    public GameObject player;
    private FirePlaceSpell firePlaceSpell;
    void Start()
    {
        firePlaceSpell = player.GetComponent<FirePlaceSpell>();
    }

    public void FirePlaceSpellButton()
    {
        firePlaceSpell.isFirePlaceSpell = true;
    }
}

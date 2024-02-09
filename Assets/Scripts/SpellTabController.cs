using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SpellTabController : MonoBehaviour
{
    public Button basicSpellButton;
    public Button speedSpellButton;
    public Button healthSpellButton;
    public Button firePlaceButton;
    public int selectedTab = 0;
    bool showTab1 = false;
    bool showTab3 = false;

    void Start()
    {
        basicSpellButton.gameObject.SetActive(false);
        speedSpellButton.gameObject.SetActive(false);
        healthSpellButton.gameObject.SetActive(false);
        firePlaceButton.gameObject.SetActive(false);
    }

    public void GeneralTabButton()
    {        
        selectedTab = 1;
        showTab1 = !showTab1;
        showTab3 = false;
        basicSpellButton.gameObject.SetActive(showTab1); //1
        speedSpellButton.gameObject.SetActive(showTab1); //1
        healthSpellButton.gameObject.SetActive(showTab1); //1
        firePlaceButton.gameObject.SetActive(false);

    }
    
    public void CreationTabButton()
    {
        selectedTab = 2;
        showTab1 = false;
        basicSpellButton.gameObject.SetActive(false);
        speedSpellButton.gameObject.SetActive(false);
        healthSpellButton.gameObject.SetActive(false);
        firePlaceButton.gameObject.SetActive(false);
    }

    public void StructureTabButton()
    {
        selectedTab = 3;
        showTab1 = false;
        showTab3 = !showTab3;
        basicSpellButton.gameObject.SetActive(false);
        speedSpellButton.gameObject.SetActive(false);
        healthSpellButton.gameObject.SetActive(false);
        firePlaceButton.gameObject.SetActive(showTab3);
    }


    


}

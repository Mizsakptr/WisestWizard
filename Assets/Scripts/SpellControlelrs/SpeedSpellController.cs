using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSpellController : MonoBehaviour
{
    public GameObject player;
    private SpeedSpell speedSpell;  

    void Start()
    {
        speedSpell = player.GetComponent<SpeedSpell>();        
    }

    public void SpeedSpellButton()
    {
        speedSpell.targetTime = 10f;
        speedSpell.isSpeedSpell = true;
    }
}

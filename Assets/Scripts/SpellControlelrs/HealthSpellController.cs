using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpellController : MonoBehaviour
{
    public GameObject player;
    private HealthSpell healthSpell;

    void Start()
    {
        healthSpell = player.GetComponent<HealthSpell>();
    }

    public void HealthSpellButton()
    {
        healthSpell.isHealthSpell = true;
    }
}

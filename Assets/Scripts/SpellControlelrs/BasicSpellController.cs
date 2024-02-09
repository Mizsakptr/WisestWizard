using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpellController : MonoBehaviour
{
    public GameObject player;
    private BasicSpell basicSpell;

    void Start()
    {
        basicSpell = player.GetComponent<BasicSpell>();
    }

    public void BasicSpellButton()
    {
        basicSpell.isBasicSpell = true;
    }
}

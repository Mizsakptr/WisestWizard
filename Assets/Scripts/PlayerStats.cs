using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int playerBaseHealth = 10;
    public int playerBaseMana = 10;
    public int playerXP = 0;
    public int playerLevel = 1;
    public float playerBaseSpeed = 1f;
    public float playerBaseHealthRegen = 1f;
    public float playerBaseManaRegen = 1f;


    public int currentHealth;
    public int currentMana;
    public int currentXP;

    public HealthBar healthBar;
    public ManaBar manaBar;
    public TextMeshProUGUI level;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI xpText;
    public XPBar xpBar;
    int playerMaxHealth = 10;
    int playerMaxMana = 10;

    public float healthTimer = 10f;
    public float manaTimer = 10f;
    float interval = 10f;


    void Start()
    {
      // playerMaxHealth = playerBaseHealth * playerLevel;
       currentHealth = playerMaxHealth;
      // 
      //
      // playerMaxMana = playerBaseMana * playerLevel;
       currentMana = playerMaxMana;
      // 
      //
       currentXP = 0;
      // xpBar.SetMaxXP(10);
      // xpBar.SetXP(currentXP % 10);
    }

    void Update()
    {
        playerMaxHealth = playerBaseHealth * playerLevel;
        healthBar.SetMaxHealth(playerMaxHealth);
        healthBar.SetHealth(currentHealth);

        playerMaxMana = playerBaseMana * playerLevel;
        manaBar.SetMaxMana(playerMaxMana);
        manaBar.SetMana(currentMana);

        xpBar.SetMaxXP(10);
        xpBar.SetXP(currentXP % 10);


        if (currentHealth < playerMaxHealth)
        {

            healthTimer -= Time.deltaTime;            

            if (healthTimer <= 0.0f)
            {
                currentHealth += 1;
                healthTimer = interval / playerBaseHealthRegen;                
            }

        }

        if (currentMana < playerMaxMana)
        {

            manaTimer -= Time.deltaTime;

            if (manaTimer <= 0.0f)
            {
                currentMana += 1;
                manaTimer = interval / playerBaseManaRegen;
            }

        }       



        //Debug

        if (Input.GetKeyDown(KeyCode.H)) {
            currentHealth -= 1;
            healthBar.SetHealth(currentHealth);
        }

        if (Input.GetKeyDown(KeyCode.M)) {
            currentMana += 1;
            manaBar.SetMana(currentMana);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            currentXP += 1;
            xpBar.SetXP(currentXP % 10);
        }

        //igen,ez is, mert ennek nem itt van a helye
        level.text = "Level: " + playerLevel;
        healthText.text = currentHealth + "/" + playerMaxHealth;
        manaText.text = currentMana + "/" + playerMaxMana;
        xpText.text = currentXP + "/" + playerLevel*10;
        //de talán ezeknek igen
        playerLevel = (currentXP / 10) + 1;
        playerBaseHealthRegen = playerLevel;
        playerBaseManaRegen = playerLevel;


    }
}

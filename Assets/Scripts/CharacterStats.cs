using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Info")]
    public string characterName;
    public int level;

    [Header("General Stats")]
    public float health;
    public float maxHealth;
    public float aether;
    public float maxAether;
    public float stamina;
    public float maxStamina;
    public float adrenaline;
    public float maxAdrenaline;

    [Header("Base Stats")] // base stat for players but armor can influence the base stat
    public float strength; //increase damage done by physical attack
    public float intelligence;
    public float agility;
    public float vitality;

    [Header("Armor Stats based on armor equipped")]
    public float attack; //based on weapon equipped
    public float defense; //reduces damage dealt by physical attack Damage * (255 - Defense)/256) + 1
    public float evasion; //% chance for attack miss
    public float hitRate; //% chance for attack tendency

    [Header("Booleans")]
    public bool inCombat = false;
    public bool isStaminaRegenerating = false; 

    //Check Stats
    public void CheckHealth()
    {
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
            
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    public void CheckStamina()
    {
        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
        }

        if (stamina <= 0)
        {
            stamina = 0;
        }
    }

    public void CheckAether()
    {
        if (aether >= maxAether)
        {
            aether = maxAether;
        }

        if (aether <= 0)
        {
            aether = 0;
        }
    }

    public void CheckAdrenaline()
    {
        if (adrenaline >= maxAdrenaline)
        {
            adrenaline = maxAdrenaline;
        }

        if (adrenaline <= 0)
        {
            adrenaline = 0;
        }
    }

    //Add Stats
    public void Heal(float amount)
    {
        health += amount;
        CheckHealth();
    }

    public void AddAether(float amount)
    {
        aether += amount;
        CheckAether();
    }

    public void AddStamina(float amount)
    {
        stamina += amount;
        CheckStamina();
    }

    public void AddAdrenaline(float amount)
    {
        adrenaline += amount;
        CheckAdrenaline();
    }

    //Remove Stat
    public void RemoveHealth(float amount)
    {
        health -= amount;
        CheckHealth();
    }

    public void RemoveAether(float amount)
    {
        aether -= amount;
        CheckAether();
    }

    public void RemoveStamina(float amount)
    {
        stamina -= amount;
        CheckStamina();
    }

    public void RemoveAdrenaline(float amount)
    {
        adrenaline -= amount;
        CheckAdrenaline();
    }

    public virtual void Die()
    {
        Debug.Log("You died!");
    }

    public virtual void LevelUp()
    {
        //increase level
        level++;

        maxHealth += 20;
        maxStamina += 20;
        maxAether += 20;

        if (!inCombat)
        {
            Heal(maxHealth);
            AddStamina(maxStamina);
            AddAether(maxAether);
        }

        //increase base stats
        strength += 4;
        intelligence += 4;
        agility += 4;
        vitality += 4; 

}

}

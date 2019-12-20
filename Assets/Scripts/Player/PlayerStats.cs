using UnityEngine;

public class PlayerStats : CharacterStats
{
    [Header("Player Stats")]
    public int experiencePoints;
    public int gold;

    [Header("Decrease and Regen Variables")]
    public float regenHealthAmount = 0f;
    public float regenStaminaAmount = 0f;
    public float regenAetherAmount = 0f;

    public float buildAdrenalineAmount = 0.05f;

    public float decreaseStaminaAmount = 0f;
    public float decreaseAetherAmount = 0f;
    public float decreaseAdrenalineAmount = 0f;


    private PlayerHUD playerHUD = null;
    private void Start()
    {
        playerHUD = GetComponent<PlayerHUD>();
        SetDefaultStats();
    }

    private void Update()
    {
            if (health < maxHealth && !inCombat)
            {
                RegenHealth();
            }

            if (stamina < maxStamina && !inCombat)
            {
                RegenStamina();
            }

            if (aether < maxAether && !inCombat)
            {
                RegenAether();
            }

        AdrenalineManagement();
        

        /*
        //test key
        if (Input.GetKeyDown(KeyCode.T))
        {
            LevelUp();
        }*/
    }

    public void SetDefaultStats()
    {
        level = 1;
        experiencePoints = 0;
        gold = 0;

        maxHealth = 50f;
        health = maxHealth;
        maxAether = 50f;
        aether = maxAether;
        maxStamina = 50f;
        stamina = maxStamina;
        maxAdrenaline = 5f;
        adrenaline = 0f;

        strength = 1f;
        intelligence = 1f;
        agility = 1f;
        vitality = 1f;
        attack = 1f;
        defense = 1;
        evasion = 1f;
        hitRate = 1f;

        regenHealthAmount = 1f;
        regenStaminaAmount = 1f;
        regenAetherAmount = 1f;

        //adrenaline management
        buildAdrenalineAmount = 0.08f;
        decreaseAdrenalineAmount = 0.08f;

}

    //regen stat
    public void RegenHealth()
    {
        Heal(regenHealthAmount * Time.deltaTime);
        playerHUD.UpdateHealthStat();
    }

    public void RegenStamina()
    {
        AddStamina(regenStaminaAmount * Time.deltaTime);
        isStaminaRegenerating = true;
        playerHUD.UpdateStaminaStat();
    }

    public void RegenAether()
    {
        AddAether(regenAetherAmount * Time.deltaTime);
        playerHUD.UpdateAetherStat();
    }

    public void BuildAdrenaline()
    {
        AddAdrenaline(buildAdrenalineAmount * Time.deltaTime);
        playerHUD.UpdateAdrenalineStat();
    }

    //decrease stat
    public void DecreaseStamina()
    {
        RemoveStamina(decreaseStaminaAmount * Time.deltaTime);
        isStaminaRegenerating = false;
        playerHUD.UpdateStaminaStat();
    }

    public void DecreaseAether()
    {
        RemoveAether(decreaseAetherAmount * Time.deltaTime);
        playerHUD.UpdateAetherStat();
    }

    public void DecreaseAdrenaline()
    {
        RemoveAdrenaline(decreaseAdrenalineAmount * Time.deltaTime);
        playerHUD.UpdateAdrenalineStat();
    }

    public override void LevelUp()
    {
        base.LevelUp();
    }

    public void AdrenalineManagement()
    {
        if (inCombat && !isStaminaRegenerating)
        {
            BuildAdrenaline();
        }

        if (!inCombat && isStaminaRegenerating)
        {
            DecreaseAdrenaline();
        }

    }

    public void TransferStaminaEnergyToAether()
    {
        if (inCombat)
        {
            DecreaseStamina();
            RegenAether();

            if (aether == maxAether)
            {
                //do special combo
                //physical weapon becomes magical weapon
                //afflicts elemental condition
                //then resets adrenaline to zero
                //set stamina to half
            }
        }

        if (!inCombat)
        {
            RegenStamina();
            DecreaseAether();
        }
    }

    public void TransferAetherEnergyToStamina()
    {
        if (inCombat)
        {
            DecreaseAether();
            RegenStamina();

            if (stamina == maxStamina)
            {
                //do special combo
                //magical weapon becomes physical weapon
                //inflicts ailment condition
                //then resets adrenaline to zero
                //set aether to half
            }
        }

        if (!inCombat)
        {
            RegenAether();
            DecreaseStamina();

        }
    }

}

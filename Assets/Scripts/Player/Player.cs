using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStats PlayerStats;
    public PlayerCombo PlayerCombo;

    [SerializeField] private float combatUpdate = 0.3f;
    [SerializeField] private bool inCombat;
    [SerializeField] private bool isWieldingPhysicalWeapon;
    
    private PlayerHUD playerHud;

    private void Awake()
    {
        playerHud = GetComponent<PlayerHUD>();
        InvokeRepeating(nameof(HandleCombat), 0, combatUpdate);
        InvokeRepeating(nameof(HandleOutOfCombat), 0, combatUpdate);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayerStats.LevelUp();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerStats.Health -= 25f;
        }
    }


    private void HandleOutOfCombat()
    {
        if (inCombat) return;

        if (PlayerStats.Health < PlayerStats.Health.MaxValue)
        {
            RegenStat(ref PlayerStats.Health, PlayerStats.RegenHealthAmount);
            playerHud.UpdateHealthStat();
        }

        if (PlayerStats.Adrenaline <= PlayerStats.Adrenaline.MaxValue && PlayerStats.Adrenaline != 0f)
        {
            DecreaseStat(ref PlayerStats.Adrenaline, PlayerStats.decreaseAdrenalineAmount);
            playerHud.UpdateAdrenalineStat();
        }

        if (isWieldingPhysicalWeapon) 
        {
            if (PlayerStats.Stamina < PlayerStats.Stamina.MaxValue)
            {
                RegenStat(ref PlayerStats.Stamina, PlayerStats.regenStaminaAmount);
                playerHud.UpdateStaminaStat();
            }

            if (PlayerStats.Aether <= PlayerStats.Aether.MaxValue && PlayerStats.Aether != 0f)
            {
                DecreaseStat(ref PlayerStats.Aether, PlayerStats.decreaseAetherAmount);
                playerHud.UpdateAetherStat();
            }
        }
        
        if (!isWieldingPhysicalWeapon)
        {
            if (PlayerStats.Aether < PlayerStats.Aether.MaxValue)
            {
                RegenStat(ref PlayerStats.Aether, PlayerStats.regenAetherAmount);
                playerHud.UpdateAetherStat();
            }

            if (PlayerStats.Stamina <= PlayerStats.Stamina.MaxValue && PlayerStats.Stamina != 0f )
            {
                DecreaseStat(ref PlayerStats.Stamina, PlayerStats.decreaseStaminaAmount);
                playerHud.UpdateStaminaStat();
            }
        }
        
    }
    private void HandleCombat()
    {
        if (!inCombat) return;

        if (PlayerStats.Adrenaline < PlayerStats.Adrenaline.MaxValue)
        {
            RegenStat(ref PlayerStats.Adrenaline, PlayerStats.buildAdrenalineAmount);
            playerHud.UpdateAdrenalineStat();
        }

        if (isWieldingPhysicalWeapon)
        {
            if (PlayerStats.Stamina <= PlayerStats.Stamina.MaxValue)
            {
                DecreaseStat(ref PlayerStats.Stamina, PlayerStats.decreaseStaminaAmount);
                playerHud.UpdateStaminaStat();
            }

            if (PlayerStats.Aether < PlayerStats.Aether.MaxValue)
            {
                RegenStat(ref PlayerStats.Aether, PlayerStats.regenAetherAmount);
                playerHud.UpdateAetherStat();
            }

        }

        if (!isWieldingPhysicalWeapon)
        {
            if (PlayerStats.Aether <= PlayerStats.Aether.MaxValue)
            {
                DecreaseStat(ref PlayerStats.Aether, PlayerStats.decreaseAetherAmount);
                playerHud.UpdateAetherStat();
            }

            if (PlayerStats.Stamina < PlayerStats.Stamina.MaxValue)
            {
                RegenStat(ref PlayerStats.Stamina, PlayerStats.regenStaminaAmount);
                playerHud.UpdateStaminaStat();
            }
        }
    }

    private void RegenStat(ref Stat stat, float regenAmount)
    {
        stat += regenAmount;
    }

    private void DecreaseStat(ref Stat stat, float decreaseAmount)
    {
        stat -= decreaseAmount;
    }

}
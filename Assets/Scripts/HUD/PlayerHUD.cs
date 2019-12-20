using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private Text healthStatText = null;
    [SerializeField] private Text aetherStatText = null;
    [SerializeField] private Text adrenalineStatText = null;
    [SerializeField] private Text staminaStatText = null;

    private CharacterStats playerTriangleStats = null;

    private void Start()
    {
        playerTriangleStats = GetComponent<PlayerStats>();
        SetAllStat();
    }

    //set stats hud
    public void UpdateHealthStat()
    {
        healthStatText.text = playerTriangleStats.health.ToString("0");
    }

    public void UpdateAetherStat()
    {
        aetherStatText.text = playerTriangleStats.aether.ToString("0");
    }

    public void UpdateAdrenalineStat()
    {
        adrenalineStatText.text = playerTriangleStats.adrenaline.ToString("0");
    }

    public void UpdateStaminaStat()
    {
        staminaStatText.text = playerTriangleStats.stamina.ToString("0");
    }

    public void SetAllStat()
    {
        UpdateHealthStat();
        UpdateAetherStat();
        UpdateAdrenalineStat();
        UpdateStaminaStat();
    }
}

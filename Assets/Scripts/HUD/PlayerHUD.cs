using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    [SerializeField] private Text healthStatText = null;
    [SerializeField] private Text aetherStatText = null;
    [SerializeField] private Text adrenalineStatText = null;
    [SerializeField] private Text staminaStatText = null;

    private void Start()
    {
        SetAllStat();
    }

    //set stats hud
    public void UpdateHealthStat()
    {
        healthStatText.text = playerStats.Health.Value.ToString(CultureInfo.CurrentCulture);
    }

    public void UpdateAetherStat()
    {
        aetherStatText.text = playerStats.Aether.Value.ToString(CultureInfo.CurrentCulture);
    }

    public void UpdateAdrenalineStat()
    {
        adrenalineStatText.text = playerStats.Adrenaline.Value.ToString(CultureInfo.CurrentCulture);
    }

    public void UpdateStaminaStat()
    {
        staminaStatText.text = playerStats.Stamina.Value.ToString(CultureInfo.CurrentCulture);
    }

    public void SetAllStat()
    {
        UpdateHealthStat();
        UpdateAetherStat();
        UpdateAdrenalineStat();
        UpdateStaminaStat();
    }
}

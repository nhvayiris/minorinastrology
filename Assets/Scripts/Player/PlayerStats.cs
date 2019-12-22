using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats")]
public class PlayerStats : CharacterStats
{
    [Header("Player Stats")] 
    public int experiencePoints;
    public int gold;
    
    [SerializeField] private int aether;
    [SerializeField] private int stamina;
    [SerializeField] private float maxAdrenaline = 5f;

    [Header("Decrease and Regen Variables")]
    [SerializeField] private float regenHealthAmount;

    public float regenStaminaAmount = 0f;
    public float regenAetherAmount = 0f;

    public float buildAdrenalineAmount = 0.05f;

    public float decreaseStaminaAmount = 0f;
    public float decreaseAetherAmount = 0f;
    public float decreaseAdrenalineAmount = 0f;

    public float RegenHealthAmount => regenHealthAmount;


    private PlayerHUD playerHUD = null;
    public override void LevelUp()
    {
        base.LevelUp();

        Health.AddToMax(20);
        Stamina.AddToMax(20);
        Aether.AddToMax(20);

        //increase base stats
        strength += 4;
        intelligence += 4;
        agility += 4;
        vitality += 4;
    }

    public override void SetDefaultStats()
    {
        base.SetDefaultStats();
        experiencePoints = 0;
        gold = 0;

        Aether = aether;
        Stamina = stamina;
        Adrenaline = 0;
        Adrenaline.SetMax(maxAdrenaline);

        regenStaminaAmount = 1f;
        regenAetherAmount = 1f;

        //adrenaline management
        buildAdrenalineAmount = 0.08f;
        decreaseAdrenalineAmount = 0.08f;

    }

}

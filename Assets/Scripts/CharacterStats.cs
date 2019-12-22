using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : ScriptableObject
{
    [Header("Info")]
    public string characterName;
    public int level;

    [Header("General Stats")]
    [SerializeField] private int health;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;

    public Stat Health;
    public Stat Aether;
    public Stat Stamina;
    public Stat Adrenaline;
    public Stat MovementSpeed;
    public Stat JumpSpeed;

    [Header("Base Stats")] // base stat for players but armor can influence the base stat
    public Stat strength; //increase damage done by physical attack
    public Stat intelligence;
    public Stat agility;
    public Stat vitality;

    [Header("Armor Stats based on armor equipped")]
    public Stat attack; //based on weapon equipped
    public Stat defense; //reduces damage dealt by physical attack Damage * (255 - Defense)/256) + 1
    public Stat evasion; //% chance for attack miss
    public Stat hitRate; //% chance for attack tendency

    public virtual void SetDefaultStats()
    {
        Health = health;
        MovementSpeed = movementSpeed;
    }

    public virtual void LevelUp()
    {
        level++;
    }

    //public virtual void Recover()
    //{
    //    Health = Health.MaxValue;
    //    Stamina = Stamina.MaxValue;
    //    Aether = Aether.MaxValue;
    //}

    private void OnEnable()
    {
        SetDefaultStats();
    }

}

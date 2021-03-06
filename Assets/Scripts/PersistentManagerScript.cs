﻿using UnityEngine;

public class PersistentManagerScript : MonoBehaviour
{
    public static PersistentManagerScript Instance { get; private set; }

    // Variables for StatsManager script (This creates variables and keeps all values always reliable)
    public bool GameReset = false;

    public int PlayerHealth = 100; // WIP
    public int PlayerMana;
    public int maxMana = 30;
    public bool Run = false;

    public int EnemyHealth;
    public int EnemyMaxHealth;

    public bool LvlGet = false; //If player gets level true or false

    public bool GameStart = true;
    public int Lvl, PlayerClass, SkillPoints, Str, Agi, Dex, Int, Con, Luck, Cha, Wis, CritHit;
    public int AllStats; // not in use atm

    public bool StartRandomCrit = true;
    public int Randomizer100 = 100;

    public bool IsCritical = false;

    public bool FightScreen = false;
    public bool EnemyTurn = false;
    public bool PlayerTurn = false;

    public bool BasicAttack = false;
    public bool SuperAttack = false;
    public bool UltraAttack = false;
    public bool BasicDefense = false;

    public int XPScreen = 0; // 0 = No screen, 1 = Fight screen,
    public int XPpoints;
    public bool XPStart;
    public int EnDies = 0;
    public int EnLvl;

    public bool StunActive;
    public bool PoisonActive;
    public bool ConfusionActive;
    public bool WeakenActive;
    public bool SlowActive;
    public bool BurnActive;

    public int WorldMapPos; // 1 = Home, 2 = Grass, 3 = Oasis, 4 = Tundra, 5 = Volcanic
    public int MapChange = 0;

    private void Awake()
    {
       
        if (Instance == null) //if instance contains no data (when game starts) -> dont destroy
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
     
        }
        else
        {
            Destroy(gameObject); //if instance already contains data -> destroy duplicant (dont create again)
        }

        if (Instance != null && GameReset == true)
        {
            Destroy(gameObject);
            GameReset = false;
        }
        else
        {
            GameReset = false;
        }


    }

    public void Update()
    {

        CritHit = Luck / 4;

        if (StartRandomCrit == true) // If true -> Start randomizing number from 0 - 100
        {
            CriticalHitChance();
            
        }

    }


    public void CriticalHitChance()
    {
        Randomizer100 = 100; // randomizer variable
        Randomizer100 = Random.Range(0, 100); // Random number from 0 to 100

        if (Randomizer100 <= CritHit)
        {

            IsCritical = true;


        }
        else
        {
            IsCritical = false;

        }

        StartRandomCrit = false;

    }

    public void StatsChecker() // Not in use atm
    {
        AllStats = Lvl + PlayerClass + Str + Agi + Dex + Int + Con + Luck + Cha + Wis + CritHit;

        if (GameReset == true)
        {
            GameReset = false;
           
            PlayerHealth = 100;
        }


    }





}

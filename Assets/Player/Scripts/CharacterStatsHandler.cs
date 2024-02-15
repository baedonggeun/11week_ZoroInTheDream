using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStats baseStats;
    public CharacterStats CurrentStates { get; private set; }
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();

    public float Addedspeed;
    public int Addedhp;

    #region Singleton
    public static CharacterStatsHandler instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        UpdateCharacterStats();
    }
    #endregion

    private void UpdateCharacterStats()
    {
        AttackSO attackSO = null;
        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        CurrentStates = new CharacterStats { attackSO = attackSO };
        // TODO
        CurrentStates.statsChangeType = baseStats.statsChangeType;
        CurrentStates.maxHealth = baseStats.maxHealth + Addedhp;
        CurrentStates.speed = baseStats.speed + Addedspeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            TakeDamage();
            Debug.Log("플레이어가 맞았습니다");
        }
    }

    private void TakeDamage()
    {
        if (CurrentStates.maxHealth > 0)
        {
            CurrentStates.maxHealth -= 1;
        }
        else if (CurrentStates.maxHealth == 0)
        {
            Die();
        }
    }

    private void Die()
    {

    }
}
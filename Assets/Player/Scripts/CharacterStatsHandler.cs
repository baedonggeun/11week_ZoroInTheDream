using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStats baseStats;
    public CharacterStats CurrentStates { get; private set; }
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();

    public float Addedspeed;
    public int Addedhp;

    public Image Health;

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
            Debug.Log("�÷��̾ �¾ҽ��ϴ�");
        }
    }

    private void TakeDamage()
    {
        if (CurrentStates.maxHealth > 0)
        {
            CurrentStates.maxHealth -= 1;
            Health.fillAmount -= 0.2f;
        }
        else if (CurrentStates.maxHealth == 0)
        {
            Die();
            Health.fillAmount = 0f;
        }
    }

    private void Die()
    {

    }
}
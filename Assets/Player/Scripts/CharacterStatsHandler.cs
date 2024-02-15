using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEditor.Build.Content;
using UnityEngine.SceneManagement;


public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStats baseStats;
    public CharacterStats CurrentStates { get; private set; }
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();

    [SerializeField] private GameObject gameOver;

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            TakeDamage();
            Debug.Log("플레이어가 맞았습니다.");
        }
    }

    private void TakeDamage()
    {
        if (CurrentStates.maxHealth > 0)
        {
            CurrentStates.maxHealth -= 1;
            Health.fillAmount -= 0.2f;

            if(CurrentStates.maxHealth == 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Health.fillAmount = 0f;
        Time.timeScale = 0f;

        gameOver.SetActive(true);
    }

    public void OnRetryButton()
    {
        SceneManager.LoadScene("StartScene");
    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}

[Serializable]
public class CharacterStats  
{
    public StatsChangeType statsChangeType;
    [Range(1, 5)] public int maxHealth;  // 최대체력 범위
    [Range(1f, 20f)] public float speed;  // 속도 범위
    public AttackSO attackSO;
}
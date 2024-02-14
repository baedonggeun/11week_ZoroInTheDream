using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownCharacterController _contoller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;
    private ProjectileManager _projectileManager;

    private void Awake()
    {
        _contoller = GetComponent<TopDownCharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _contoller.OnAttackEvent += OnShoot;
        _contoller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;
    }

    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackData rangedAttackData = attackSO as RangedAttackData;
        float projectilesAngleSpace = rangedAttackData.multipleProjectilesAngel;
        int numberOfProjectilesPerShot = rangedAttackData.numberofProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackData.multipleProjectilesAngel;


        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSpread;
            CreateProjectile(rangedAttackData, angle);
        }
    }

    private void CreateProjectile()
    {
        // TODO
        Instantiate(testPrefab, projectileSpawnPosition);
    }
}
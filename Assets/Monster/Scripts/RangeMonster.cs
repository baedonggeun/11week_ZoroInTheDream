using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMonster : MonsterController
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 3f;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        float distance = Vector3.Distance(transform.position, target.position);
        Vector2 direction = new Vector2((target.position.x - transform.position.x), (target.position.y - transform.position.y)).normalized;

        if (distance < followRange)
        {
            if (distance <= attackRange)
            {
                if (attackDelay >= attackRate)
                {
                    AttackTarget(direction);
                }
                MoveToTarget(Vector2.zero);
            }
            else
            {
                MoveToTarget(direction);
            }
            MoveToTarget(direction);
            Rotate();
        }
    }

    private void AttackTarget(Vector2 direction)
    {
        attackDelay = 0f;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed * Time.deltaTime);
    }
}

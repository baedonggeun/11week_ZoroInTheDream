using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ContactMonster : MonsterController
{
    protected override void Update()
    {
        base.Update();

        float distance = Vector3.Distance(transform.position, target.position);
        Vector2 direction = (target.transform.position - transform.position).normalized;

        if (distance < followRange)
        {
            if (distance <= attackRange)    
            {
                AttackTarget();
                MoveToTarget(Vector2.zero);
            }
            else
            {
                MoveToTarget(direction);
            }
        }
        MoveToTarget(direction);
        Rotate();
    }

    private void AttackTarget() // 공격하는 함수
    {
        //animator.SetTrigger("attack");
        attackDelay = 0;
        // 플레이어 피격 함수
    }


}

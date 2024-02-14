using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ContactMonster : MonsterController
{
    protected override void Update()
    {
        base.Update();

        Vector3 direction = DirectionToTarget().normalized;
        float distance = DistanceToTarget();

        //if (distance < followRange)
        //{
        //    if (distance <= attackRange && attackDelay == 0)
        //    {

        //    }
        //    else
        //    {
        //        MoveToTarget(direction);
        //    }
        //}
        MoveToTarget(direction);
        //Rotate(direction);

    }

    private void AttackTarget() // 공격하는 함수
    {
        //animator.SetTrigger("attack");
        attackDelay = attackSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ContactMonster : MonsterController
{
    protected override void Update()
    {
        base.Update();

        //Vector2 direction = DirectionToTarget();
        //float distance = DistanceToTarget();

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
        //MoveToTarget(direction);
        //Rotate(direction);

    }

    private void AttackTarget()
    {
        //animator.SetTrigger("attack");
       // attackDelay = attackSpeed;
    }
}

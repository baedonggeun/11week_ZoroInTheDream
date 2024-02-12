using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalItemManager : MonoBehaviour
{
    Item item;

    float movementspeed;
    void Start()
    {
        movementspeed = transform.GetComponentInParent<TopDownMovement>().speed;

        movementspeed += item.MovementSpeed;
    }
}

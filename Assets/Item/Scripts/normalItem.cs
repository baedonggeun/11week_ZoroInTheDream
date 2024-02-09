using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class normalItem : MonoBehaviour
{
    public Item item;

    float movementspeed;
    //Player
    private void Start()
    {
        


    }


    public void SetItem(Item _item)
    {
        item.Name = _item.Name;
        item.MovementSpeed = _item.MovementSpeed;

        Debug.Log(GetComponentInParent<TopDownMovement>().speed);
        Debug.Log(item.MovementSpeed);
        GetComponentInParent<TopDownMovement>().speed += item.MovementSpeed;
        Debug.Log(GetComponentInParent<TopDownMovement>().speed);
    }
}

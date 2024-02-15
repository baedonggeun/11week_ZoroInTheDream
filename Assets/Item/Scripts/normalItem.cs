using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class normalItem : MonoBehaviour
{
    public Item item;

    public SpriteRenderer image;
    //Player
    private void Start()
    {



    }


    public void SetItem(Item _item)
    {
        item.Name = _item.Name;
        item.MovementSpeed = _item.MovementSpeed;
        item.AttackSpeed = _item.AttackSpeed;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;
        image.sprite = item.itemImage;

        CharacterStatsHandler.instance.Addedspeed += item.MovementSpeed;
        //hp 구현하지 않기로함.
        //CharacterStatsHandler.instance.Addedhp += item.Hp;
        PlayerAttack.instance.cooltime -= item.AttackSpeed;
    }
}

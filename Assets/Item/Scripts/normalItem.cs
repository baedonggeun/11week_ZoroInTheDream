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





    public void SetItem(Item _item)
    {
        item.Name = _item.Name; 
        item.MovementSpeed = _item.MovementSpeed;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;
        item.AttackSpeed = _item.AttackSpeed;
        image.sprite = item.itemImage;

        CharacterStatsHandler.instance.Addedspeed = item.AttackSpeed;
        CharacterStatsHandler.instance.Addedhp = item.Hp;
        //todo : °ø¼Ó
    } 
     
    //
    public void DestoryItem(Item _item)
    {
        CharacterStatsHandler.instance.Addedspeed = 0;
        CharacterStatsHandler.instance.Addedhp = 0;
    }


}

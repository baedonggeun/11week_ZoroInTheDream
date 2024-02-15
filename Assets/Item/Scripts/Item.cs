using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item
{
    public enum ItemType
    {
        Weapon,//무기마다 공격 방식 변경...
        Armor,//체력
        Shose,//이독속도
        Glove,//공격속도
        Etc//potion?
    }
    public ItemType itemType;
    public string Type, Name, Desc;
    public float Atk, Def, Hp, MovementSpeed, AttackSpeed;
    public Sprite itemImage;
    public bool isEquied;

}

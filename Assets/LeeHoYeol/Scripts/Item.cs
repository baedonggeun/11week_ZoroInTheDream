using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Weapon,
        Hat,
        Armor,
        Ring,
        Etc//potion?
    }
    public ItemType itemType;
    public string Type, Name, Desc;
    public int Gold, Atk, Def, Number;
    public Sprite itemImage;
    public bool isEquied;
}

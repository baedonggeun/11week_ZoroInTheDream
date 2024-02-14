using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    #region Singleton
    public static ItemManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion
    public void GetRandomNormalItem()
    {
        for (int i = 0; i < ItemDatabase.instance.itemDB.Count; i++)
        {
            if (ItemDatabase.instance.itemDB[i].itemType != Item.ItemType.Weapon)
                ItemSlot.instance.AddItemSlot(ItemDatabase.instance.itemDB[i]);
        }
    }


    public void GetRandomWeaponItem()
    {
        for (int i = 0; i < ItemDatabase.instance.itemDB.Count; i++)
        {
            if (ItemDatabase.instance.itemDB[i].itemType == Item.ItemType.Weapon)
                ItemSlot.instance.AddItemSlot(ItemDatabase.instance.itemDB[i]);
        }
    }
}

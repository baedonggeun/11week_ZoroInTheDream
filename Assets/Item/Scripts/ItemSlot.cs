using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    #region Singleton
    public static ItemSlot instance;
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

    public List<Item> itemSlot = new List<Item>();

    private int slotCount;

    public void AddItemSlot(Item _item)
    {
        if (slotCount < 5)
        {
            itemSlot.Add(_item);
            Debug.Log("�������� �����߽��ϴ�.");
            slotCount = itemSlot.Count;
        }
        Debug.Log("������ ������ �����մϴ�.");
    }


}

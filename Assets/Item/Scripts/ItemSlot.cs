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

    private int slotCount = 5;

    public void AddItemSlot(Item _item)
    {
        if (slotCount < 5)
        {
            itemSlot.Add(_item);
            Debug.Log("�������� �����߽��ϴ�.");
        }
        Debug.Log("������ ������ �����մϴ�.");
    }


}

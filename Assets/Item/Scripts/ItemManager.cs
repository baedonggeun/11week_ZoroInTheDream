using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEditor.Progress;

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

    public GameObject itemprefeb;
    public GameObject player;

    //�� Ŭ����� �⺻������ ȹ��� �޼���
    public void GetNormalItem()
    {
        int i = Random.Range(0, 6);

        if (ItemSlot.instance.AddItemSlot(ItemDatabase.instance.itemDB[i]))
        {
            GameObject item = Instantiate(itemprefeb);
            item.transform.SetParent(player.transform);
            item.GetComponentInChildren<normalItem>().SetItem(ItemDatabase.instance.itemDB[i]);
        }
        
    }

    
    public void GetWeaponItem()
    {

        ItemSlot.instance.AddItemSlot(ItemDatabase.instance.itemDB[0]);

        GameObject item2 = Instantiate(itemprefeb);
        item2.transform.parent = player.transform;
        item2.GetComponent<normalItem>().SetItem(ItemDatabase.instance.itemDB[0]);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    #region Singleton
    public static ItemDatabase instance;
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
    public List<Item> itemDB = new List<Item>();

    public GameObject itemprefeb;
    public GameObject player;

    void Start()
    {
        //test용 shose(이속증가)
        GameObject item = Instantiate(itemprefeb);
        item.transform.parent = player.transform;
        item.GetComponent<normalItem>().SetItem(itemDB[2]);//shose
    }

}

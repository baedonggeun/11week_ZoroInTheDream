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
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;
        image.sprite = item.itemImage;

        if (item.itemType == Item.ItemType.Shose)
        {
            //Debug.Log(GetComponentInParent<TopDownMovement>().speed);
            //Debug.Log(item.MovementSpeed);
            //GetComponentInParent<TopDownMovement>().speed += item.MovementSpeed;
            //Debug.Log(GetComponentInParent<TopDownMovement>().speed);

            //todo : Shose transform.position ����.
        }

        if (item.itemType == Item.ItemType.Armor)
        {
            // GetComponentInParent<TopDownMovement>().speed += item.Hp;

            //todo : ���� ü�°������� ������Ʈ ������ ��ġ �ٲ����.
        }

        if (item.itemType == Item.ItemType.Glove)
        {
            // GetComponentInParent<TopDownMovement>().speed += item.AttackSpeed;

            //todo : ���� ���Ӱ������� ������Ʈ ������ ��ġ �ٲ����.
        }

        /*
         * ? : ��� �̷��� �ص� �������. normal�����۵� ���̿� ���̰� ����, ����
         * ���ð��� ���� ���ݷ°� ������ ���� ���� �������� ����⿡�� ����
        GetComponentInParent<TopDownMovement>().speed += item.MovementSpeed;
        GetComponentInParent<TopDownMovement>().speed += item.Hp;
        GetComponentInParent<TopDownMovement>().speed += item.AttackSpeed;
        */
    }
    
    
    //todo : player �⺻ speed,atkspeed, �� �⺻ ������ nomalitem.cs�� ����.
    //item�� Destory, Change ������ ���� ��ȭ�� ������ ������� �����ϴ� �Լ�.
    //���ʿ� Speed++ �ϱ⺸�ٴ� new AddedSpeed�� �־��ҵ�. speed�� ��� �����۰Ÿ��� ���װ� �������Ű���.
}

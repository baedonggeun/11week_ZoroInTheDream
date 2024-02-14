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

            //todo : Shose transform.position 조정.
        }

        if (item.itemType == Item.ItemType.Armor)
        {
            // GetComponentInParent<TopDownMovement>().speed += item.Hp;

            //todo : 윗줄 체력관련으로 컴포넌트 참조로 수치 바꿔야함.
        }

        if (item.itemType == Item.ItemType.Glove)
        {
            // GetComponentInParent<TopDownMovement>().speed += item.AttackSpeed;

            //todo : 윗줄 공속관련으로 컴포넌트 참조로 수치 바꿔야함.
        }

        /*
         * ? : 사실 이렇게 해도 상관없음. normal아이템들 사이에 차이가 없고, 추후
         * 가시갑옷 같은 공격력과 방어력을 같이 가진 아이템을 만들기에도 용이
        GetComponentInParent<TopDownMovement>().speed += item.MovementSpeed;
        GetComponentInParent<TopDownMovement>().speed += item.Hp;
        GetComponentInParent<TopDownMovement>().speed += item.AttackSpeed;
        */
    }
    
    
    //todo : player 기본 speed,atkspeed, 등 기본 스텟을 nomalitem.cs등 저장.
    //item이 Destory, Change 등으로 스텟 변화가 있을때 원래대로 조정하는 함수.
    //애초에 Speed++ 하기보다는 new AddedSpeed로 둬야할듯. speed를 계속 만지작거리면 버그가 많아질거같음.
}

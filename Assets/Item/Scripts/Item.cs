using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item
{
    public enum ItemType
    {
        Weapon,//���⸶�� ���� ��� ����...
        Armor,//ü��
        Shose,//�̵��ӵ�
        Glove,//���ݼӵ�
        Etc//potion?
    }
    public ItemType itemType;
    public string Type, Name, Desc;
    public float Atk, Def, Hp, MovementSpeed, AttackSpeed;
    public Sprite itemImage;
    public bool isEquied;

}

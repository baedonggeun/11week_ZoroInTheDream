using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerAttack : MonoBehaviour
{

    public GameObject fireball;
    public Transform mousePos;
    public GameObject staff;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject fireBall = Instantiate(fireball);
            fireBall.transform.SetParent(staff.transform);
            //todo : weaponitem�� �´� component(scripts��) �߰�.
        }
    }
}

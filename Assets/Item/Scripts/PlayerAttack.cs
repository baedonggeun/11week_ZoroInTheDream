using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerAttack : MonoBehaviour
{

    public GameObject fireball;
    public Transform mousePos;
    public GameObject staff;

    public float cooltime;
    private float curtime;
    // Update is called once per frame
    void Update()
    {
        if (curtime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject fireBall = Instantiate(fireball);
                fireBall.transform.SetParent(staff.transform);
                //todo : weaponitem에 맞는 component(scripts형) 추가.
                curtime = cooltime;
            }
            
        }
        curtime -= Time.deltaTime;
        Debug.Log(curtime);
    }
}

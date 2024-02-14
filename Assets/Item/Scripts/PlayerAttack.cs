using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerAttack : MonoBehaviour
{

    public GameObject fireball;
    //public Transform playerPos;
    public GameObject weapon;

    public float cooltime;
    private float curtime;
    // Update is called once per frame
    void Update()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
        if (curtime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Instantiate(fireball, playerPos.position, transform.rotation);
                Instantiate(fireball, gameObject.GetComponentInParent<Transform>().position, transform.rotation);
                //todo : weaponitem에 맞는 component(scripts형) 추가.
                curtime = cooltime;
            }
            
        }
        curtime -= Time.deltaTime;
    }
}

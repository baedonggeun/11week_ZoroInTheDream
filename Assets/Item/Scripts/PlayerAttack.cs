using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerAttack : MonoBehaviour
{

    #region Singleton
    public static PlayerAttack instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();

    }
    #endregion

    SoundManager soundManager;


    public GameObject fireball;
    //public Transform playerPos;
    public GameObject weapon;
    public TextMeshProUGUI AttackSpeedText;

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
                SoundManager.instance.PlaySFX(soundManager.fireBallClip);
                //Instantiate(fireball, playerPos.position, transform.rotation);
                Instantiate(fireball, gameObject.GetComponentInParent<Transform>().position, transform.rotation);
                //todo : weaponitem�� �´� component(scripts��) �߰�.
                curtime = cooltime;
            }
            
        }
        curtime -= Time.deltaTime;
        AttackSpeedText.text = cooltime.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float cooltime;
    private float curtime;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        DestoryBullet();
    }

    // Update is called once per frame
    void Update()
    {
        //todo : Vector MousePos 받아야함.
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Monster") || collision.transform.CompareTag("Wall"))
        {
            animator.SetTrigger("isHit");
            Debug.Log("명중!");
            Destroy(gameObject, 0.4f);
            speed = 0f;
        }
    }

    void DestoryBullet()
    {
        //todo : die animation 끝날때까지의 시간정도 뒤에 Destory하게 만들어야함.
        Destroy(gameObject, 3f);
    }

    private void MonsterHit(GameObject monster)
    {

    }
}

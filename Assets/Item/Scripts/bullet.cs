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
        //todo : Vector MousePos �޾ƾ���.
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Monster") || collision.transform.CompareTag("Wall"))
        {
            animator.SetTrigger("isHit");
            Debug.Log("����!");
            Destroy(gameObject, 0.4f);
            speed = 0f;
        }
    }

    void DestoryBullet()
    {
        //todo : die animation ������������ �ð����� �ڿ� Destory�ϰ� ��������.
        Destroy(gameObject, 3f);
    }

    private void MonsterHit(GameObject monster)
    {

    }
}

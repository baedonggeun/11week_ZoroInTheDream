using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float cooltime;
    private float curtime;

    Animator animator;
    // Start is called before the first frame update
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
            DestoryBullet();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody2D rb;
    private Transform target;

    private void Start()
    {
        target = target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 dir = target.position - transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(dir * speed, ForceMode2D.Impulse);
        DestroyBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player") || collision.transform.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject, 3f);
    }
}

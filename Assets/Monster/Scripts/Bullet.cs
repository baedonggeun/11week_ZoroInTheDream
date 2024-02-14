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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

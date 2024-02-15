using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : MonoBehaviour
{
    private Transform target;
    public int health = 1000;
    private float walkSpeed = 3;
    private float rushSpeed = 6;
    public GameObject StonePrefab;
    public SpriteRenderer BossRender;
    private int walkCount = 0;
    private Rigidbody2D rb;

    private Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Invoke("Think", 2);
    }

    private void Update()
    {
        Think();
        Rotate();
    }

    void Rush()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        transform.position += direction * rushSpeed * Time.deltaTime;
        Debug.Log("rush");
        //walkCount++;
        //if (walkCount < 50)
        //    Invoke("Rush", 0.1f);
        //else
        //{
        //    walkCount = 0;
            Invoke("Think", 3);
        //}
    }

    void ThrowStone()
    {
        GameObject Stone = Instantiate(StonePrefab, transform.position, transform.rotation);
        Debug.Log("throw");

        Invoke("Think", 3);
    }

    void Move()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        transform.position += direction * walkSpeed * Time.deltaTime;
        Debug.Log("move");
        //walkCount++;
        //if (walkCount < 30)
        //    Invoke("Rush", 0.1f);
        //else
        //{
        //    walkCount = 0;
            Invoke("Think", 3);
        //}
    }

    void stop()
    {
        transform.Translate(Vector2.zero);
    }

    void Think()
    {
        int patternIndex = Random.Range(0, 3);

        switch (patternIndex)
        {
            case 0:
                Move();
                break;
            case 1:
                Rush();
                break;
            case 2:
                ThrowStone();
                break;
            default:
                return;
                break;
        }
    }

    protected void Rotate()
    {
        Vector2 direction = target.position - transform.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        BossRender.flipX = Mathf.Abs(rotZ) > 90f;
    }

    public void TakeDamage(int damageAmount) // 대미지 받는 함수
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        BossRender = transform.GetComponentInChildren<SpriteRenderer>();
        walkSpeed = 0;
        collider.enabled = false;
        Color color = BossRender.color;
        color.a = 0.3f;
        BossRender.color = color;
        // animator.SetTrigger("IsDead"); // ani 제작 후 
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bullet")/* 플레이어 공격 태그?  */)
        {
            TakeDamage(100 /* 플레이어의 공격 데미지 */);
            Debug.Log(health);
        }
    }
}

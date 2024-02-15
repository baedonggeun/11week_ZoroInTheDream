using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMonster : MonoBehaviour
{
    private Transform target;
    public int health = 1000;
    private float walkSpeed = 5;
    private float rushSpeed = 20;
    public GameObject StonePrefab;
    public SpriteRenderer BossRender;
    private int walkCount = 0;
    private Rigidbody2D rb;

    private Collider2D collider;

    [SerializeField] private Image bossHealthImage;

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
        
        Rotate();
    }

    void Rush()
    {
        StartCoroutine("rushCoroutine");
        Invoke("Think", 1);
        
    }

    void ThrowStone()
    {
        GameObject Stone = Instantiate(StonePrefab, transform.position, transform.rotation);
        Debug.Log("throw");

        Invoke("Think", 3);
    }

    void Move()
    {
        StartCoroutine("MoveCoroutine");
        
        Invoke("Think", 3);
        
    }

    IEnumerator MoveCoroutine()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        while (true)
        {
            transform.position += direction * walkSpeed * Time.deltaTime;
            Debug.Log("move");
            yield return new WaitForSeconds(0.03f);
        }
    }

    IEnumerator rushCoroutine()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        while (true)
        {
            transform.position += direction * rushSpeed * Time.deltaTime;
            Debug.Log("rush");
            yield return new WaitForSeconds(0.01f);
        }
    }

    void stop()
    {
        transform.Translate(Vector2.zero);
    }

    void Think()
    {
        StopAllCoroutines();
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

        bossHealthImage.fillAmount -= 0.1f;
    }

    public void Die() //  ㅁ
    {
        BossRender = transform.GetComponentInChildren<SpriteRenderer>();
        walkSpeed = 0;
        collider.enabled = false;
        Color color = BossRender.color;
        color.a = 0.3f;
        BossRender.color = color;
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bullet")/* 플레이어 공격 태그?  */)
        {
            TakeDamage(1 /* 플레이어의 공격 데미지 */);
            Debug.Log(health);
        }
    }
}

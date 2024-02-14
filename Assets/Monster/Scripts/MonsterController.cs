using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterController : MonoBehaviour
{
    protected Transform target;
    public int health = 100;
    public float speed = 5f;
    public int damage = 1;
    public float attackRate = 1f;
    public float attackRange = 1f;
    public float followRange = 10f;
    public float attackDelay = 0f;
    public string targetTag = "Player";
    [SerializeField] private SpriteRenderer mobRender;

    protected Rigidbody2D rb;
    protected Collider2D collider;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    protected void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).transform; // 태그가 player인 게임오브젝트를 타겟으로 설정
        attackDelay = 0f;
    }

    protected virtual void Update()
    {
        attackDelay += Time.deltaTime; // 공격 
    }

    protected void MoveToTarget(Vector2 direction)
    {      
        transform.Translate(direction * speed * Time.deltaTime);
        // animator.SetBool("Moving", true); //animation 적용시 
    }

    protected void Rotate()
    {
        Vector2 direction = target.position - transform.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        mobRender.flipX = Mathf.Abs(rotZ) > 90f;
    }

    public void TakeDamage(int damageAmount) // 대미지 받는 함수
    {
        health -= damageAmount;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        speed = 0;
        collider.enabled = false;
        // animator.SetTrigger("IsDead"); // ani 제작 후 
        Destroy(gameObject, 1);
    }

    
}

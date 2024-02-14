using System;
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
    public float attackDelay = 1f;
    public string targetTag = "Player";
    protected float attackSpeed = 1f;
    protected SpriteRenderer mobRender;

    protected Rigidbody2D rb;
    protected Collider2D collider;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    protected void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).transform; 
    }

    protected virtual void Update()
    {
        attackDelay -= Time.deltaTime;
    }

    protected void MoveToTarget(Vector2 direction)
    {
        
        transform.Translate(direction * speed * Time.deltaTime);
        
    }

    protected void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        mobRender.flipX = Mathf.Abs(rotZ) > 90f;
    }

    protected Vector2 DirectionToTarget()
    {
        return (transform.position - transform.position).normalized;
    }

    protected float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, target.position);
    }

    public void TakeDamage(int damageAmount)
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
        // animator.SetTrigger("IsDead");
        Destroy(gameObject, 1);
    }

    
}

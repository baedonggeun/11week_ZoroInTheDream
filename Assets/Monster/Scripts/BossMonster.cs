using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : MonoBehaviour
{
    private Transform target;
    public int health = 0;
    private float walkSpeed = 3;
    private float rushSpeed = 6;
    public GameObject StonePrefab;
    public SpriteRenderer BossRender;
    private int walkCount = 0;


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
        Debug.Log("달리기");
        //walkCount++;
        //if (walkCount < 50)
        //    Invoke("Rush", 0.1f);
        //else
        //{
        //    walkCount = 0;
        //    Invoke("Think", 3);
        //}
    }

    void ThrowStone()
    {
        GameObject Stone = Instantiate(StonePrefab, transform.position, transform.rotation);
        Debug.Log("던지기");

       // Invoke("Think", 3);
    }

    void Move()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        transform.position += direction * walkSpeed * Time.deltaTime;
        Debug.Log("걷기");
        //walkCount++;
        //if (walkCount < 30)
        //    Invoke("Rush", 0.1f);
        //else
        //{
        //    walkCount = 0;
        //    Invoke("Think", 3);
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
}

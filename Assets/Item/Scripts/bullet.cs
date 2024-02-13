using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float cooltime;
    private float curtime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //todo : Vector MousePos 받아야함.
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    void DestoryBullet()
    {
        Destroy(gameObject);
    }
}

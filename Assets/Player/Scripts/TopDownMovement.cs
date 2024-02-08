using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += (new Vector3(x, y)).normalized * Time.deltaTime * speed;

        Vector3 mousePos = Input.mousePosition;
    }
}
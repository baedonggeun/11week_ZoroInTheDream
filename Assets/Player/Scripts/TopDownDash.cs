using System.Collections;
using UnityEngine;

public class TopDownDash : MonoBehaviour
{
    public float dashSpeed = 10f;
    public float dashTime = 0.5f;
    private float currentDashTime;

    private Rigidbody2D rb;
    private bool isDashing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            isDashing = true;
            currentDashTime = dashTime;

            Vector2 dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            rb.AddForce(dashDirection * dashSpeed, ForceMode2D.Impulse);
            Debug.Log("´­¸²");
        }

        if (isDashing)
        {
            if (currentDashTime > 0)
            {
                currentDashTime -= Time.deltaTime;
            }
            else
            {
                isDashing = false;
            }
        }
    }
}
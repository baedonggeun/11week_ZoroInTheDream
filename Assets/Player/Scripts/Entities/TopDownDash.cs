using System.Collections;
using UnityEngine;

public class TopDownDash : MonoBehaviour
{
    [SerializeField] float startDashTime = 1f;
    [SerializeField] float dashSpeed = 1f;

    Rigidbody2D rb;

    float currentDashTime;

    bool canDash = true;
    bool playerCollision = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canDash && Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.W))
            {
                StartCoroutine(Dash(Vector2.up));
            }

            else if (Input.GetKey(KeyCode.A))
            {
                StartCoroutine(Dash(Vector2.left));
            }

            else if (Input.GetKey(KeyCode.S))
            {
                StartCoroutine(Dash(Vector2.down));
            }

            else if (Input.GetKey(KeyCode.D))
            {
                StartCoroutine(Dash(Vector2.right));
            }

            else
            {
                // Whatever you want.
            }

        }
    }

    IEnumerator Dash(Vector2 direction)
    {
        canDash = false;
        playerCollision = false;
        currentDashTime = startDashTime; // Reset the dash timer.

        while (currentDashTime > 0f)
        {
            currentDashTime -= Time.deltaTime; // Lower the dash timer each frame.

            rb.velocity = direction * dashSpeed; // Dash in the direction that was held down.
                                                 // No need to multiply by Time.DeltaTime here, physics are already consistent across different FPS.

            yield return null; // Returns out of the coroutine this frame so we don't hit an infinite loop.
        }

        rb.velocity = new Vector2(0f, 0f); // Stop dashing.

        canDash = true;
        playerCollision = true;
    }
}
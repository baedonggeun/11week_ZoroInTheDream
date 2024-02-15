using System.Collections;
using UnityEngine;

public class TopDownDash : MonoBehaviour
{
    public float dashDistance = 5f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private bool canDash = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(PerformDash());
        }
    }

    IEnumerator PerformDash()
    {
        canDash = false;

        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + transform.forward * dashDistance;

        float elapsedTime = 0f;

        while (elapsedTime < dashDuration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / dashDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
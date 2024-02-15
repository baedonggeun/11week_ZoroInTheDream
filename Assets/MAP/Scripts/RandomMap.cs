using UnityEditor.EditorTools;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("문에 닿음");
            DoorManager.instance.PassThroughDoor();
        }
    }
}
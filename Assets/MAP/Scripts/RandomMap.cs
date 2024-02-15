using UnityEditor.EditorTools;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 플레이어가 문을 통과하면 문을 관리하는 스크립트 호출
            DoorManager doorManager = GetComponentInParent<DoorManager>();
            if (doorManager != null)
            {
                doorManager.PassThroughDoor();
            }
        }
    }
}
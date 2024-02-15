using UnityEditor.EditorTools;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // �÷��̾ ���� ����ϸ� ���� �����ϴ� ��ũ��Ʈ ȣ��
            DoorManager doorManager = GetComponentInParent<DoorManager>();
            if (doorManager != null)
            {
                doorManager.PassThroughDoor();
            }
        }
    }
}
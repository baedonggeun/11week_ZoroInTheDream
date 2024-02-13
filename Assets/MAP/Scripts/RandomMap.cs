using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �浹�� ��ü�� "Player" �±׸� ������ �ִ��� Ȯ�� ���� �÷��̾�� �浹�ߴٸ� ������ ����
        {
            MapLogic gameManager = FindObjectOfType<MapLogic>();
            if (gameManager != null && gameManager.GetComponent<MapLogic>().doorSpawned)
            {
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //  충돌한 객체가 "Player" 태그를 가지고 있는지 확인
        {
            MapLogic gameManager = FindObjectOfType<MapLogic>();
            if (gameManager != null && gameManager.GetComponent<MapLogic>().doorSpawned)
            {
                Destroy(gameObject);
            }
        }
    }
}

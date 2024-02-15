using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RandomMap gameManager = FindObjectOfType<RandomMap>();
            if (gameManager != null && gameManager.GetComponent<RandomMap>().doorSpawned)
            {
                Destroy(gameObject);
            }
        }
    }
}

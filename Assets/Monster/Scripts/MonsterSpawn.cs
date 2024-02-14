using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    private int spawnCount = 0;
    private int waveSpawnCount = 0;
    private int waveSpawnPosCount = 0;

    public float spawnInterval = 0.5f;
    public List<GameObject> enemyPrefebs = new List<GameObject>();
    [SerializeField] private Transform spawnPosRoot;
    private List<Transform> spawnPos = new List<Transform>();

    private void Start()
    {
        
    }

    IEnumerator StartNextMap()
    {

    }
}

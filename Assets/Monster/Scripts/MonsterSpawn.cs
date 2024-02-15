using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] private int enemyCount = 0;
    [SerializeField] private int mapSpawnCount = 0;
    [SerializeField] private int mapSpawnPosCount = 0;

    public List<GameObject> enemyPrefebs = new List<GameObject>();
    [SerializeField] private Transform spawnPosRoot;
    private List<Transform> spawnPos = new List<Transform>();

    private void Awake()
    {
        for (int i = 0; i < spawnPosRoot.childCount; i++)
        {
            spawnPos.Add(spawnPosRoot.GetChild(i));
        }
    }

    private void Start()
    {
        CreateMonster();
    }

    private void CreateMonster()
    {
        for(int i = 0; i < mapSpawnPosCount; i++)
        {
            int posIdx = Random.Range(0, spawnPos.Count);
            for(int j = 0; j < mapSpawnCount; j++)
            {
                int prefabIdx = Random.Range(0, enemyPrefebs.Count);
                GameObject enemy = Instantiate(enemyPrefebs[prefabIdx], spawnPos[posIdx].position, Quaternion.identity);
            }
        }
    }
}

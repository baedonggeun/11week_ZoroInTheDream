using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] private int enemyCount = 0;
    public int mapSpawnCount = 0;
    [SerializeField] private int mapSpawnPosCount = 5;
    private int stageNumber = 0;

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

    private void Update()
    {
        DoorManager doorManager = DoorManager.instance;
        if (stageNumber != doorManager.stageNumber)
        {
            stageNumber = doorManager.stageNumber;
            mapSpawnCount = MonsterSpawnCount(stageNumber);
            StartCoroutine(CreateMonster());
        }
    }


    IEnumerator CreateMonster()
    {
        for(int i = 0; i < mapSpawnCount; i++)
        {
            int posIdx = Random.Range(0, spawnPos.Count);
            
            int prefabIdx = Random.Range(0, enemyPrefebs.Count);
            GameObject enemy = Instantiate(enemyPrefebs[prefabIdx], spawnPos[posIdx].position, Quaternion.identity);

            yield return new WaitForSeconds(1f);
            
        }
    }

    public int MonsterSpawnCount(int stageNumber)
    {
        if(stageNumber != 6 && stageNumber != 11)
        {
            mapSpawnCount = stageNumber * 4 + 3;
        }

        return mapSpawnCount;
    }
}

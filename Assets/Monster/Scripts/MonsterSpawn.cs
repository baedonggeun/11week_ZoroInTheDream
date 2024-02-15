using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MonsterSpawn : MonoBehaviour
{
    [HideInInspector] public int mapSpawnCount = 0;
    [SerializeField] private int mapSpawnPosCount = 5;

    public List<GameObject> enemyPrefebs = new List<GameObject>();
    [SerializeField] private Transform spawnPosRoot;
    private List<Transform> spawnPos = new List<Transform>();

    int monsterStage = 0;

    

    private void Awake()
    {
        for (int i = 0; i < spawnPosRoot.childCount; i++)
        {
            spawnPos.Add(spawnPosRoot.GetChild(i));
        }
    }

    private void Update()
    {
        StartCoroutine(MonsterSpawnMethod());
    }

    IEnumerator MonsterSpawnMethod()
    {
        DoorManager doorManager = DoorManager.instance;

        if(monsterStage != doorManager.stageNumber)
        {
            monsterStage = doorManager.stageNumber;

            mapSpawnCount = MonsterSpawnCount(monsterStage);

            StartCoroutine(CreateMonster());

            yield break;
        }
        else
        {
            yield break;
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
            mapSpawnCount = stageNumber * 3 + 2;
        }

        return mapSpawnCount;
    }
}

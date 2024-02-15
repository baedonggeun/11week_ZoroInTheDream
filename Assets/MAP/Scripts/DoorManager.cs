using TMPro;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject Map1, Map2, Map3, CompensationMap, BossMap;


    public Transform player;

    private int allMonstersDefeated = 0;

    public int stageNumber = 1;

    [HideInInspector] public int randomMap = 0;
    [HideInInspector] public float mapSize_x = 0f;
    [HideInInspector] public float mapSize_y = 0f;


    #region Singleton
    public static DoorManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion


    void Update()
    {
        //MonsterRemain();
        


    }
    private void Start()
    {
        PassThroughDoor();
    }

    public void MonsterRemain()
    {
        MonsterSpawn monsterSpawn = new MonsterSpawn();
        int monsterCount = monsterSpawn.mapSpawnCount;

        
    }

    // 모든 몬스터가 처지면 호출되는 함수
    public void AllMonstersDefeated()
    {
        allMonstersDefeated = 0;
    }

    // 문이 활성화되어 있는지 확인
    private bool IsDoorActive()
    {
        return transform.childCount > 0;
    }




    // 문을 통과할 때 호출되는 함수
    public void PassThroughDoor()
    {
        ItemManager.instance.GetNormalItem();
        player.position = new Vector3(0, 0, 0);
        stageNumber++;      //다음 스테이지로 이동

        Map.instance.StageStepText(stageNumber);        //스테이지 이동 시, 맵 이미지와 상단 텍스트 변경
        Map.instance.bossHealthPopUP(stageNumber);      //보스 스테이지의 경우(14번째 맵) 보스 체력 active
        NextMap();
        MapSizeSetting();

    }

    public void NextMap()
    {
        randomMap = Random.Range(0, 3);

        if (stageNumber == 6 || stageNumber == 11)
        {
            randomMap = 3;

            Map1.SetActive(false);
            Map2.SetActive(false);
            Map3.SetActive(false);
            CompensationMap.SetActive(true);
        }
        else if (stageNumber == 14)
        {
            randomMap = 4;

            CompensationMap.SetActive(false);
            Map1.SetActive(false);
            Map2.SetActive(false);
            Map3.SetActive(false);
            BossMap.SetActive(true);
        }
        else
        {
            if (randomMap == 0)
            {
                Map1.SetActive(true);
                Map2.SetActive(false);
                Map3.SetActive(false);
            }
            else if (randomMap == 1)
            {
                Map1.SetActive(false);
                Map2.SetActive(true);
                Map3.SetActive(false);
            }
            else if (randomMap == 2)
            {
                Map1.SetActive(false);
                Map2.SetActive(false);
                Map3.SetActive(true);
            }
        }
    }

    public void MapSizeSetting()        //맵 종류에 따라 size 세팅
    {
        switch (randomMap)
        {
            case 0:
                mapSize_x = 18.5f;
                mapSize_y = 14.0f;
                break;
            case 1:
                mapSize_x = 22.5f;
                mapSize_y = 11.0f;
                break;
            case 2:
                mapSize_x = 10.5f;
                mapSize_y = 21.5f;
                break;
            case 3:
                mapSize_x = 10.5f;
                mapSize_y = 8f;
                break;
                //case 4:
                //break;
                //bossmap
        }
    }


}

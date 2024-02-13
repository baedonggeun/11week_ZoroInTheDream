using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLogic : MonoBehaviour
{
    public Tilemap[] tilemaps;
    public GameObject[] stage;
    public GameObject NextStage; // 다음 스테이지를 가리키는 게임 오브젝트
    public bool doorSpawned = false; // 문이 생성되었는지 여부를 나타냄
    public Vector3 doorPosition;
    private int monsterKillCount = 0; // 처치한 몬스터의 수를 저장

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) //  플레이어가 'W' 키를 눌렀고 이미 문이 생성되었으며 몬스터를 충분히 처치했다면 다음 스테이지로 이동
        {
            if (doorSpawned && monsterKillCount >= 20)
            {
                int randomStageIndex = Random.Range(0, stage.Length);
                GameObject nextStage = stage[randomStageIndex];

                Instantiate(nextStage, doorPosition, Quaternion.identity);
            }
        }
    }

    public void MonsterKilled() // 몬스터를 처치한 수를 증가
    {
        monsterKillCount++;
        if (monsterKillCount >= 20 && !doorSpawned)
        {
            Instantiate(NextStage, doorPosition, Quaternion.identity);
            doorSpawned = true;
        }
    }
}
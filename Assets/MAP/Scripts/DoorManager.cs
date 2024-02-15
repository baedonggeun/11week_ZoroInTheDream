using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject doorPrefab;
    public GameObject[] maps;

    private bool allMonstersDefeated = false;

    public int stageNumber = 1;

    void Update()
    {
        // 모든 몬스터가 처지면 문을 생성하고 활성화
        if (allMonstersDefeated && !IsDoorActive())
        {
            ActivateDoor();
        }
    }

    // 모든 몬스터가 처지면 호출되는 함수
    public void AllMonstersDefeated()
    {
        allMonstersDefeated = true;
    }

    // 문이 활성화되어 있는지 확인
    private bool IsDoorActive()
    {
        return transform.childCount > 0;
    }

    // 문을 활성화하는 함수
    private void ActivateDoor()
    {
        GameObject[] rooms = GetRoomsToChooseFrom();
        int randomIndex = Random.Range(0, rooms.Length);
        GameObject randomRoom = rooms[randomIndex];

        Vector3 doorPosition = CalculateDoorPosition(randomRoom);
        GameObject newDoor = Instantiate(doorPrefab, doorPosition, Quaternion.identity, transform);
        newDoor.SetActive(true);
    }

    // 문의 위치를 계산하는 함수 (각 맵마다 다른 위치에 배치)
    private Vector3 CalculateDoorPosition(GameObject room)
    {
        return room.transform.position;
    }

    // 랜덤하게 선택할 방들의 배열 반환
    private GameObject[] GetRoomsToChooseFrom()
    {
        // 마지막 방이 보스 방이 되도록 설정
        GameObject[] rooms = new GameObject[maps.Length + 1];
        for (int i = 0; i < maps.Length; i++)
        {
            rooms[i] = maps[i];
        }

        return rooms;
    }

    // 문을 통과할 때 호출되는 함수
    public int PassThroughDoor()
    {
        // 랜덤하게 맵 선택
        int randomIndex = Random.Range(0, maps.Length);
        GameObject randomMap = maps[randomIndex];

        Map mapStage = new Map();

        stageNumber++;      //다음 스테이지로 이동

        mapStage.StageStepText(stageNumber);        //스테이지 이동 시, 맵 이미지와 상단 텍스트 변경

        // 선택된 맵을 활성화하고 나머지는 비활성화
        foreach (GameObject map in maps)
        {
            map.SetActive(map == randomMap);
        }

        // 모든 몬스터가 처지지 않은 상태로 초기화
        allMonstersDefeated = false;
        return randomIndex;
    }


    private Vector3 GetRandomPositionInMap(GameObject map)
    {
        // 맵의 중앙으로부터 일정 범위 내의 랜덤한 위치를 반환
        float rangeX = 5f; // X 축 범위
        float rangeY = 10f; // Y 축 범위
        Vector3 mapCenter = map.transform.position;
        float randomX = Random.Range(mapCenter.x - rangeX, mapCenter.x + rangeX);
        float randomY = Random.Range(mapCenter.y - rangeY, mapCenter.y + rangeY);
        float z = 0f;
        return new Vector3(randomX, randomY, z);
    }
}

using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject doorPrefab;
    public GameObject[] maps;

    private bool allMonstersDefeated = false;

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
        foreach (GameObject map in maps)
        {
            if (map.activeSelf)
            {
                Vector3 doorPosition = CalculateDoorPosition(map);
                GameObject newDoor = Instantiate(doorPrefab, doorPosition, Quaternion.identity, transform);
                newDoor.SetActive(true);
                return;
            }
        }
    }

    // 문의 위치를 계산하는 함수 (각 맵마다 다른 위치에 배치)
    private Vector3 CalculateDoorPosition(GameObject map)
    {
        return map.transform.position;
    }

    // 문을 통과할 때 호출되는 함수
    public void PassThroughDoor()
    {
        // 플레이어의 위치를 맵 내부의 랜덤한 위치로 이동
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // 랜덤한 맵 선택
            int randomIndex = Random.Range(0, maps.Length);
            GameObject randomMap = maps[randomIndex];

            Vector3 randomPosition = GetRandomPositionInMap(randomMap);
            player.transform.position = randomPosition;

            // 선택된 맵을 활성화하고 나머지는 비활성화
            foreach (GameObject map in maps)
            {
                map.SetActive(map == randomMap);
            }

            // 모든 몬스터가 처지지 않은 상태로 초기화
            allMonstersDefeated = false;
        }
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

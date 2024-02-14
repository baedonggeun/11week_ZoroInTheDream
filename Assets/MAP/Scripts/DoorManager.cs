using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject doorPrefab; // 문 프리팹
    public GameObject[] maps; // 맵 오브젝트들

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
        // 여기에 각 맵마다 다른 문 위치를 계산하는 로직을 추가하세요
        // 예를 들어, 맵의 중앙에 배치하는 등의 방법을 사용할 수 있습니다.
        // 이 예제에서는 간단하게 맵의 중앙에 배치하는 것으로 가정하겠습니다.
        return map.transform.position;
    }

    // 문을 통과할 때 호출되는 함수
    public void PassThroughDoor()
    {
        // 랜덤하게 맵 선택
        int randomIndex = Random.Range(0, maps.Length);
        GameObject randomMap = maps[randomIndex];

        // 선택된 맵을 활성화하고 나머지는 비활성화
        foreach (GameObject map in maps)
        {
            map.SetActive(map == randomMap);
        }

        // 모든 몬스터가 처지지 않은 상태로 초기화
        allMonstersDefeated = false;
    }
}

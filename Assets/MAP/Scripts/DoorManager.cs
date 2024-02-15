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
    public int PassThroughDoor()
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

        return randomIndex;
    }
}

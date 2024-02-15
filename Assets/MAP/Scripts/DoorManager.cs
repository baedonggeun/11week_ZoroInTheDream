using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject doorPrefab;
    public GameObject[] maps;

    private bool allMonstersDefeated = false;

    void Update()
    {
        // ��� ���Ͱ� ó���� ���� �����ϰ� Ȱ��ȭ
        if (allMonstersDefeated && !IsDoorActive())
        {
            ActivateDoor();
        }
    }

    // ��� ���Ͱ� ó���� ȣ��Ǵ� �Լ�
    public void AllMonstersDefeated()
    {
        allMonstersDefeated = true;
    }

    // ���� Ȱ��ȭ�Ǿ� �ִ��� Ȯ��
    private bool IsDoorActive()
    {
        return transform.childCount > 0;
    }

    // ���� Ȱ��ȭ�ϴ� �Լ�
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

    // ���� ��ġ�� ����ϴ� �Լ� (�� �ʸ��� �ٸ� ��ġ�� ��ġ)
    private Vector3 CalculateDoorPosition(GameObject map)
    {
        return map.transform.position;
    }
    // ���� ����� �� ȣ��Ǵ� �Լ�
    public void PassThroughDoor()
    {
        // �÷��̾��� ��ġ�� ������ �� ������ ������ ��ġ�� �̵�
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // ������ �� ����
            int randomIndex = Random.Range(0, maps.Length);
            GameObject randomMap = maps[randomIndex];

            Vector3 randomPosition = GetRandomPositionInMap(randomMap);
            player.transform.position = randomPosition;

            // ���õ� ���� Ȱ��ȭ�ϰ� �������� ��Ȱ��ȭ
            foreach (GameObject map in maps)
            {
                map.SetActive(map == randomMap);
            }

            // ��� ���Ͱ� ó���� ���� ���·� �ʱ�ȭ
            allMonstersDefeated = false;
        }
    }

    private Vector3 GetRandomPositionInMap(GameObject map)
    {
        // ���� �߾����κ��� ���� ���� ���� ������ ��ġ�� ��ȯ
        float rangeX = 5f; // X �� ����
        float rangeY = 10f; // Y �� ����
        Vector3 mapCenter = map.transform.position;
        float randomX = Random.Range(mapCenter.x - rangeX, mapCenter.x + rangeX);
        float randomY = Random.Range(mapCenter.y - rangeY, mapCenter.y + rangeY);
        float z = 0f;
        return new Vector3(randomX, randomY, z);
    }
}

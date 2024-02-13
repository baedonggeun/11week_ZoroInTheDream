using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLogic : MonoBehaviour
{
    public Tilemap[] tilemaps;
    public GameObject[] stage;
    public GameObject NextStage; // ���������� ����Ű�� ���� ������Ʈ
    public bool doorSpawned = false; // ���� �����Ǿ����� ���θ� ��Ÿ��
    public Vector3 doorPosition;
    private int monsterKillCount = 0; // óġ�� ������ ���� ����

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) // �÷��̾ 'W' Ű�� ������ �̹� ���� �����Ǿ����� ���͸� ����� óġ�ߴٸ� ���� ���������� �̵�
        {
            if (doorSpawned && monsterKillCount >= 20)
            {
                int randomStageIndex = Random.Range(0, stage.Length);
                GameObject nextStage = stage[randomStageIndex];

                Instantiate(nextStage, doorPosition, Quaternion.identity);
            }
        }
    }

    public void MonsterKilled() // ���͸� óġ�� ���� ����
    {
        monsterKillCount++;
        if (monsterKillCount >= 20 && !doorSpawned)
        {
            Instantiate(NextStage, doorPosition, Quaternion.identity);
            doorSpawned = true;
        }
    }
}
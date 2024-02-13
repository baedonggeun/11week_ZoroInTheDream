using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLogic : MonoBehaviour
{
    public Tilemap[] tilemaps;
    public GameObject NextStagedoor;
    public bool doorSpawned = false;
    private int monsterKillCount = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (doorSpawned && monsterKillCount >= 20)
            {
                int randomIndex = Random.Range(0, tilemaps.Length);
                Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
                playerTransform.position = tilemaps[randomIndex].WorldToCell(Vector3.zero);
            }
        }
    }

    public void MonsterKilled()
    {
        monsterKillCount++;
        if (monsterKillCount >= 20 && !doorSpawned)
        {
            Vector3 randomDoorPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);

            Instantiate(NextStagedoor, randomDoorPosition, Quaternion.identity);
            doorSpawned = true;
        }
    }
}

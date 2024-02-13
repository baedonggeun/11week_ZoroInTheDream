using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLogic : MonoBehaviour
{
    public Tilemap[] tilemaps;
    public GameObject NextStagedoor;
    public bool doorSpawned = false;
    public Vector3 doorPosition;
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
            Instantiate(NextStagedoor, doorPosition, Quaternion.identity);
            doorSpawned = true;
        }
    }
}

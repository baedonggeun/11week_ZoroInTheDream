using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : DoorManager
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 cameraPosition;

    Vector2 center = new Vector2(0.5f, 0f);
    Vector2 mapSize;

    [SerializeField] float cameraMoveSpeed;
    float height;
    float width;

    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();

        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    void FixedUpdate()
    {
        LimitCameraArea();
    }

    void LimitCameraArea()      //선형 보간
    {
        transform.position = Vector3.Lerp(transform.position,
                                          playerTransform.position + cameraPosition,
                                          Time.deltaTime * cameraMoveSpeed);
        float lx = mapSize.x - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        float ly = mapSize.y - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);
    }

    private void OnDrawGizmos()     //맵 기즈모
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }

    public void MapSizeSetting()        //맵 종류에 따라 size 세팅
    {
        DoorManager doorManager = new DoorManager();

        int mapNumber = doorManager.PassThroughDoor();
        switch(mapNumber)
        {
            case 0:
                mapSize.x = 18.5f;
                mapSize.y = 14.0f;
                break;
            case 1:
                mapSize.x = 22.5f;
                mapSize.y = 11.0f;
                break;
            case 2:
                mapSize.x = 10.5f;
                mapSize.y = 21.5f;
                break;
            default:
                break;
        }

    }
}
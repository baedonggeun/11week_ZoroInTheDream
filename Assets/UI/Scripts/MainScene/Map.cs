using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Map : MonoBehaviour
{
    [SerializeField] private Transform trsMenu;
    [SerializeField] private GameObject stage_1;
    [SerializeField] private GameObject stage_2;
    [SerializeField] private GameObject stage_3;
    public GameObject bossHealth;

    public TextMeshProUGUI stageText;
    public TextMeshProUGUI stepText;
    public TextMeshProUGUI remainMonsterCount;

    bool mapOpened;

    private void Start()
    {
        mapOpened = false;
    }

    IEnumerator SlideMap()
    {
        int count = 0;

        if (mapOpened)      //메뉴 눌렀을 때, 메뉴창이 오른쪽에서 슬라이드해서 나타나도록 설정
        {
            while (count < 50)
            {
                float posY = 3.1f;

                trsMenu.transform.position += Vector3.left * posY;

                count++;

                yield return new WaitForSeconds(0.01f);
            }

            yield break;
        }
        else if (!mapOpened)        //메뉴창이 활성화된 상태로 다시 눌렀을 때, 오른쪽으로 슬라이드하여 사라지도록 설정
        {
            while (count < 50)
            {
                float posY = 3.1f;

                trsMenu.transform.position += Vector3.left * -posY;

                count++;

                yield return new WaitForSeconds(0.01f);
            }

            yield break;
        }

    }

    public void MapClose()     //투명 배경 클릭 시, inactive 하고, 메뉴 창 슬라이드 코루틴 실행
    {
        mapOpened = false;

        StartCoroutine("SlideMap");
    }

    public void OnClickMap()       //메뉴 버튼 클릭 시, 슬라이드 및 투명한 배경 active하여 어디를 클릭해도 메뉴창 닫을 수 있게 설정
    {
        if (!mapOpened)
        {
            mapOpened = true;

            StartCoroutine("SlideMap");
        }
        else if (mapOpened)
            MapClose();
    }

    public void StageStepText(int stageNumber)       //스테이지 넘어갈 때마다 상단의 스테이지 단계 수정 및 맵의 이미지 수정
    {
        if(stageNumber <= 3)
        {
            stage_1.SetActive(true);
            stage_2.SetActive(false);
            stage_3.SetActive(false);
            stageText.text = "1";
            stepText.text = stageNumber.ToString();
        }
        else if(stageNumber > 3 && stageNumber <= 8)
        {
            stage_1.SetActive(false);
            stage_2.SetActive(true);
            stage_3.SetActive(false);
            stageText.text = "2";
            stepText.text = (stageNumber - 3).ToString();
        }
        else if(stageNumber > 8)
        {
            stage_1.SetActive(false);
            stage_2.SetActive(false);
            stage_3.SetActive(true);
            stageText.text = "3";
            stepText.text = (stageNumber - 8).ToString();
        }
    }

    public void bossHealthPopUP(int stageNumber)
    {
        bossHealth.SetActive(true);
    }
}

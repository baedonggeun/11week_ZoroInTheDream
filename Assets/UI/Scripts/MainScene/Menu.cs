using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Transform trsMenu;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject characterInformaion;

    bool menuOpened;

    private void Start()
    {
        background.SetActive(false);
        menuOpened = false;
    }
    IEnumerator SlideMenuBar()      
    {
        int count = 0;

        if(menuOpened)      //메뉴 눌렀을 때, 메뉴창이 오른쪽에서 슬라이드해서 나타나도록 설정
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
        else if(!menuOpened)        //메뉴창이 활성화된 상태로 다시 눌렀을 때, 오른쪽으로 슬라이드하여 사라지도록 설정
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

    public void OnClickMenu()       //메뉴 버튼 클릭 시, 슬라이드 및 투명한 배경 active하여 어디를 클릭해도 메뉴창 닫을 수 있게 설정
    {
        if(!menuOpened)
        {
            background.SetActive(true);

            menuOpened = true;

            StartCoroutine("SlideMenuBar");
        }
        else if(menuOpened)
            MenuClose();
    }

    public void MenuClose()     //투명 배경 클릭 시, inactive 하고, 메뉴 창 슬라이드 코루틴 실행
    {
        background.SetActive(false);

        menuOpened = false;

        StartCoroutine("SlideMenuBar");
    }

    public void OnContinueButton()      //메뉴창 continue 버튼 눌렀을 경우, 메뉴 닫는 함수 실행
    {
        MenuClose();
    }

    public void OnCharacterInformaionButton()       //캐릭터 정보창 활성화
    {
        Time.timeScale = 0f;
        characterInformaion.SetActive(true);
    }

    public void OnQuitButton()      //게임 종료 버튼
    {
        Application.Quit();
    }
}
